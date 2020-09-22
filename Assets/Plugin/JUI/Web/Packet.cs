using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace JackUtil {

    [Serializable]
    public class Packet {

        public string a; // 数据地址
        public string o; // 数据内容

        public Packet(string a, string o) {

            this.a = a;
            this.o = o;

        }

        public static Packet DeserializeObject(string packetStr) {

            if (packetStr.Length < 5) {

                return null;

            }

            packetStr = packetStr.Substring(5, packetStr.Length - 5);
            Packet p = JsonConvert.DeserializeObject<Packet>(packetStr);
            return p;
            
        }

        public override string ToString() {

            string s = JsonConvert.SerializeObject(this);
            s = s.Length.ToString().PadLeft(5, '0') + s;
            return s;

        }

        public static int ReadLength(string packetStr) {

            if (packetStr.Length < 5) {

                return 0;

            } else {

                DebugUtil.Log(packetStr);

                string s = packetStr.Substring(0, 5);
                return int.Parse(s);

            }

        }

    }
}