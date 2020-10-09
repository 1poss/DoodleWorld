using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BoardLine : MonoBehaviour {

        public Text rankText;
        public Text nameText;
        public Text resultText;
        public Image avatarImg;

        public void LoadBest(UserRank userRank, bool isShowAvatar) {

            rankText.text = userRank.rank.ToString();
            nameText.text = userRank.username;
            resultText.text = userRank.result;
            
            if (isShowAvatar) {

                avatarImg.Show();

            } else {

                avatarImg.Hide();

            }

        }

    }
}