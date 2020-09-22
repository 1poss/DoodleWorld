using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace JackUtil {

    public class JcpHelper {

        TcpHelper tcpHelper;
        public event Action<Packet> RecievePacketEvent;

        public JcpHelper(string url, int port) {

            tcpHelper = new TcpHelper(url, port);
            tcpHelper.RecieveMsgEvent += RecieveMsg;
            tcpHelper.StartRecieving();

        }

        public void SendDataAsync<T>(string eventHandler, T dataObj) {

            string o = JsonConvert.SerializeObject(dataObj);

            Packet p = new Packet(eventHandler, o);

            tcpHelper.SendDataAsync(p.ToString());

        }

        void RecieveMsg(string packetStr) {

            DebugUtil.Log("RCV: " + packetStr);

            Packet p = Packet.DeserializeObject(packetStr);
            RecievePacketEvent?.Invoke(p);

        }

        public void StartRecieving() {

            tcpHelper?.StartRecieving();

        }

        public void Abort() {

            tcpHelper?.Abort();

        }

    }
}