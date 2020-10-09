using System;

namespace DoodleWorldNS {

    [Serializable]
    public class UserRank {

        public int rank { get; private set; }
        public string username { get; private set; }
        public string bestTime { get; private set; }
        public string deadTimes { get; private set; }

        public UserRank(int rank, string username, string bestTime, string deadTimes) {
            this.rank = rank;
            this.username = username;
            this.bestTime = bestTime;
            this.deadTimes = deadTimes;
        }
        
        public void SetRank(int rank) {
            this.rank = rank;
        }
    }
}