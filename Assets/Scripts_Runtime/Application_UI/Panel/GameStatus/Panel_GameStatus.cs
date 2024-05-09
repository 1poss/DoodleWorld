using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameFunctions;

namespace DoodleWorldNS.UIApplication {

    public class Panel_GameStatus : MonoBehaviour {

        [SerializeField] Image hpImg;
        [SerializeField] float perWidth;
        [SerializeField] TextMeshProUGUI timeTxt;

        char[] timeCharArray;

        public void Ctor() {
            timeCharArray = new char[40];
        }

        public void TearDown() {
            Destroy(gameObject);
        }

        public void SetHp(int hp) {
            hpImg.rectTransform.sizeDelta = new Vector2(perWidth * hp, hpImg.rectTransform.sizeDelta.y);
        }

        public void SetTime(float time) {
            int len = GFTime.SecTo_SS_XXX(time, ref timeCharArray);
            timeTxt.SetCharArray(timeCharArray, 0, len);
        }

    }
}