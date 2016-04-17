using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rtsp.Messages;
using System.Net.Sockets;
using RtspMulticaster;


    namespace RTSPimplementation
    {
    class Implementation 
    {
        public UdpClient forwardPort = new UdpClient(554);
        public PortCouple UserPorts = new PortCouple(554);

        private Dictionary<Uri, Forwarder> _listOfForwarder = new Dictionary<Uri, Forwarder>();
        /* No of forwarding ports available*/

        public List<string> _clientList { get; set; }
        /*get the ports of clients in session*/


    }
}
