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
        private SessionSyncArgs args = new SessionSyncArgs();

        public SessionSync(ILog l, ConcurrentQueue<APISpectrum> recvQueue)
        {
            log = l;
            log.Info("Creating sync service");
            running = true;
            active = false;
            recvq = recvQueue;
        }

        public void DoWork()
        {
            try
            {
                log.Info("Initializing sync service");

                while (running)
                {
                    if(active && !String.IsNullOrEmpty(args.SessionName))
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args.WSAddress + "/spectrums/" + args.SessionName + "?minIdx=" + (args.LastSessionIndex + 1));
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

                        if (active)
                        {
                            List<APISpectrum> spectrumList = JsonConvert.DeserializeObject<List<APISpectrum>>(data);
                            foreach (APISpectrum apiSpec in spectrumList)
                            {
                                recvq.Enqueue(apiSpec);
                                if (apiSpec.SessionIndex > args.LastSessionIndex)
                                    args.LastSessionIndex = apiSpec.SessionIndex;
                            }
                        }
                    }

                    Thread.Sleep(3000);
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
