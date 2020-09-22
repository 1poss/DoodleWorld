using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace JackUtil {

    [Serializable]
    public class Packet {

        public string e; // eventName
        public string o; // 数据内容

        public Packet(string a, string o) {

            this.e = a;
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

        public static Packet CutString(int length, string leftToDeal) {

            string s = leftToDeal.Substring(0, length + 5);
            Packet p = Packet.DeserializeObject(s);
            return p;

        }

        public static int ReadLength(string packetStr) {

            if (packetStr.Length < 5) {

                return 0;

            } else {

                string s = packetStr.Substring(0, 5);
                return int.Parse(s);

            }

        }

    }
}