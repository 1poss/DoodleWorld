using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace JackUtil {

    public class JcpHelper {

        TcpHelper tcpHelper;

        Dictionary<string, Action<Packet>> eventDic;

        public JcpHelper(string url, int port) {

            eventDic = new Dictionary<string, Action<Packet>>();

            tcpHelper = new TcpHelper(url, port);
            tcpHelper.RecieveMsgEvent += RecieveMsg;

        }

        public void AddEventListener(string eventName, Action<Packet> cb) {

            if (!eventDic.ContainsKey(eventName)) {

                eventDic.Add(eventName, cb);
                DebugUtil.Log("注册: " + eventName);

            } else {

                DebugUtil.LogWarning("已存在: " + eventName);

            }

        }

        void TriggerEvent(string eventName, Packet p) {

            if (eventDic.ContainsKey(eventName)) {

                // DebugUtil.Log("触发: " + eventName);

                eventDic.GetValue(eventName)?.Invoke(p);

            } else {

                DebugUtil.LogError("事件未注册: " + eventName);

            }
        }

        public void EmitEvent<T>(string eventName, T dataObj) {

            string o;

            if (dataObj is string) {

                o = dataObj as string;

            } else {

                o = JsonConvert.SerializeObject(dataObj);

            }

            Packet p = new Packet(eventName, o);

            tcpHelper.SendDataAsync(p.ToString());

        }

        async void RecieveMsg(string packetStr) {

            // DebugUtil.Log("收到: " + packetStr);

            await Task.Run(() => {

                try {

                    while(packetStr.Length > 5) {

                        // DebugUtil.Log("循环中: " + packetStr.Length);

                        int l = Packet.ReadLength(packetStr);

                        if (l == 0) {

                            DebugUtil.Log(l);
                            break;

                        }

                        Packet p = Packet.CutString(l, packetStr);

                        if (p != null) {

                            TriggerEvent(p.e, p);

                        } else {

                            DebugUtil.Log("接收的数据非Packet String");
                            break;

                        }

                        packetStr = packetStr.Substring(5 + l);

                    }

                } catch(Exception e) {

                    DebugUtil.Log("线程错误: " + e);

                }

            });

        }

        public async void StartRecieving() {

            await tcpHelper?.StartRecieving();

        }

        public void Abort() {

            tcpHelper?.Abort();

        }

    }
}