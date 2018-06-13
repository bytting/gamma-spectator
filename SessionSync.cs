using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using log4net;
using System.Net;
using Newtonsoft.Json;

namespace crash
{
    class SessionSyncArgs
    {
        public string WSAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SessionName { get; set; }
        public int LastSessionIndex { get; set; }
    }

    class SessionSync
    {
        private ILog log = null;        
        private volatile bool running;
        private bool active;
        private ConcurrentQueue<APISpectrum> recvq = null;
        private ConcurrentBag<int> syncb = null;
        private SessionSyncArgs args = new SessionSyncArgs();
        private long startTime, currentTime;

        public SessionSync(ILog l, ConcurrentQueue<APISpectrum> recvQueue, ConcurrentBag<int> syncBag)
        {
            log = l;
            log.Info("Creating sync service");
            running = true;
            active = false;
            recvq = recvQueue;
            syncb = syncBag;
        }

        public void DoWork()
        {
            try
            {
                log.Info("Initializing sync service");

                while (running)
                {
                    startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                    if (active && !String.IsNullOrEmpty(args.SessionName))
                    {                        

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args.WSAddress + "/spectrums/" + args.SessionName + "?minIdx=" + (args.LastSessionIndex + 1) + "&maxCnt=300");
                        string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(args.Username + ":" + args.Password));
                        request.Headers.Add("Authorization", "Basic " + credentials);
                        request.Timeout = 8000;
                        request.Method = WebRequestMethods.Http.Get;
                        request.Accept = "application/json";

                        string data;
                        HttpStatusCode code = Utils.GetResponseData(request, out data);

                        if (code != HttpStatusCode.OK)
                        {
                            log.Error(code.ToString() + ": " + data);
                            active = false;
                            continue;
                        }
                        
                        List<APISpectrum> spectrumList = JsonConvert.DeserializeObject<List<APISpectrum>>(data);
                        foreach (APISpectrum apiSpec in spectrumList)
                        {
                            if (!active)
                                break;

                            recvq.Enqueue(apiSpec);
                            if (apiSpec.SessionIndex > args.LastSessionIndex)
                                args.LastSessionIndex = apiSpec.SessionIndex;
                        }

                        // request sync specs
                        if (syncb.Count > 0)
                        {
                            int idx;
                            while (syncb.TryPeek(out idx))
                            {
                                if (!active)
                                    break;

                                request = (HttpWebRequest)WebRequest.Create(args.WSAddress + "/spectrums/" + args.SessionName + "/" + idx.ToString());
                                credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(args.Username + ":" + args.Password));
                                request.Headers.Add("Authorization", "Basic " + credentials);
                                request.Timeout = 8000;
                                request.Method = WebRequestMethods.Http.Get;
                                request.Accept = "application/json";

                                code = Utils.GetResponseData(request, out data);

                                if (code == HttpStatusCode.OK)
                                {
                                    int i;
                                    syncb.TryTake(out i);

                                    APISpectrum spectrum = JsonConvert.DeserializeObject<APISpectrum>(data);
                                    recvq.Enqueue(spectrum);
                                    log.Info("Synced spectrum " + spectrum.SessionIndex);
                                }
                                else
                                {
                                    log.Info("Sync failed, skipping");
                                    break;
                                }
                            }
                        }
                    }

                    currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                    int delta = (int)(currentTime - startTime);
                    int sleepTime = (delta < 3000) ? 3000 - delta : 0;
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }
     
        public void Activate(SessionSyncArgs a)
        {
            args.WSAddress = a.WSAddress;
            args.SessionName = a.SessionName;
            args.Username = a.Username;
            args.Password = a.Password;
            args.LastSessionIndex = a.LastSessionIndex;
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }

        public void RequestStop()
        {
            running = active = false;
            log.Info("Stopping sync service");
        }

        public bool IsRunning()
        {
            return running;
        }
    }
}
