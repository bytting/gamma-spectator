/*	
	Gamma Spectator - Monitoring application for Gamma Analyzer sessions
    Copyright (C) 2018  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag robole,

using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using Newtonsoft.Json;
using log4net;

namespace burn
{        
    /**
     * NetService - Threaded class for network communication
     */
    public partial class NetService
    {
        private ILog log = null;
        //! Running state for this service
        private volatile bool running;

        //! Queue with messages from server
        private ConcurrentQueue<crash.APISpectrum> recvq = new ConcurrentQueue<crash.APISpectrum>();        

        /** 
         * Constructor for the NetService         
         * \param recvQueue - Queue with messages from server
         */
        public NetService(ILog l, ref ConcurrentQueue<crash.APISpectrum> recvQueue)
        {            
            log = l;
            log.Info("Creating Net Service");            
            running = true;
            recvQueue = recvq;        
        }

        /**
         * Thread entry point
         */
        public void DoWork()
        {
            try
            {
                log.Info("Initializing Net Service");

                while (running)
                {
                    // Receive messages from web service                    

                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        /**
         * Function used to stop this service         
         */
        public void RequestStop()
        {
            running = false;
            log.Info("Stopping Net Service");
        }

        /**
         * Function used to check the running state of this service
         */
        public bool IsRunning()
        {
            return running;
        }
    }
}
