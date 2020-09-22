using System;
using System.Threading;
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
        CancellationToken token;
        CancellationTokenSource tokenSource;

        public event Action<string> RecieveMsgEvent;

        public TcpHelper(string url, int port) {

            tcp = new TcpClient(url, port);

            stream = tcp.GetStream();

        }

        ~ TcpHelper() {

            stream?.Close();
            tcp?.Close();

        }

        public void SendDataAsync(string message) {

            sendData = Encoding.UTF8.GetBytes(message);
            stream.WriteAsync(sendData, 0, sendData.Length);

        }

        public void StartRecieving() {

            tokenSource = new CancellationTokenSource();

            token = tokenSource.Token;

            Task t = new Task(async () => {

                while(true) {

                    if (token.IsCancellationRequested) {

                        return;

                    }

                    string resData = string.Empty;

                    recieveData = new byte[8192];
                    Int32 bytes = stream.Read(recieveData, 0, recieveData.Length);
                    resData = Encoding.UTF8.GetString(recieveData, 0, bytes);
                    stream.Flush();
                    RecieveMsgEvent?.Invoke(resData);

                    await Task.Delay(16);

                }

            }, token);

            t.Start();

        }

        public void Abort() {

            tokenSource.Cancel();

        }

    }
}