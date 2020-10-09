using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    [Serializable]
    public class BoardInfo {

        public UserRank me { get; private set; }
        public List<UserRank> bestList { get; private set; }

        public BoardInfo(UserRank me, List<UserRank> bestList) {
            this.me = me;
            this.bestList = bestList;
        }

    }
}