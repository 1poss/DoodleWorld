using System;

namespace DoodleWorldNS {

    [Serializable]
    public class UserRank {

        public int rank { get; private set; }
        public string username { get; private set; }
        public string result { get; private set; }

        public UserRank(int rank, string username, string result) {
            this.rank = rank;
            this.username = username;
            this.result = result;
        }
    }
}