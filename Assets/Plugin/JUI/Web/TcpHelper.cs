using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;

namespace JackUtil {

    public class TcpHelper {

        public TcpClient tcp;
        byte[] recieveData;
        byte[] sendData;
        NetworkStream stream;

        public TcpHelper(string url, int port) {

            tcp = new TcpClient(url, port);

            stream = tcp.GetStream();

        }

        ~ TcpHelper() {

            stream?.Close();
            tcp?.Close();

        }

        public void SendData(string message) {

            sendData = Encoding.UTF8.GetBytes(message);
            stream.Write(sendData, 0, sendData.Length);
            DebugUtil.Log("发送了: " + message);

        }

        public async Task<string> Recieving() {

            string resData = string.Empty;

            await Task.Run(() => {

                recieveData = new byte[8192];
                Int32 bytes = stream.Read(recieveData, 0, recieveData.Length);
                resData = Encoding.UTF8.GetString(recieveData, 0, bytes);
                stream.Flush();

            });
            
            return resData;

        }

    }
}