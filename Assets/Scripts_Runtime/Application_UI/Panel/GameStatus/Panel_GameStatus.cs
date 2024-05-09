using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            // No GC
            // Format: ss.xxx
            int len = 0;

            int sec = (int)time;
            int ms = (int)((time - sec) * 1000);

            int digit = 1;
            while (sec > 0) {
                timeCharArray[len++] = (char)(sec % 10 + '0');
                sec /= 10;
                digit++;
            }

            if (digit == 1) {
                timeCharArray[len++] = '0';
            }

            // Reverse
            Array.Reverse(timeCharArray, 0, len);

            timeCharArray[len++] = '.';
            timeCharArray[len++] = (char)(ms / 100 + '0');
            timeCharArray[len++] = (char)(ms / 10 % 10 + '0');
            timeCharArray[len++] = (char)(ms % 10 + '0');

            timeTxt.SetCharArray(timeCharArray, 0, len);

        }

    }
}