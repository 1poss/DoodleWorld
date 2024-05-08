using System;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleWorldNS.UIApplication {

    public class Panel_GameStatus : MonoBehaviour {

        [SerializeField] Image hpImg;

        [SerializeField] float perWidth;

        public void Ctor() {

        }

        public void TearDown() {
            Destroy(gameObject);
        }

        public void SetHp(int hp) {
            hpImg.rectTransform.sizeDelta = new Vector2(perWidth * hp, hpImg.rectTransform.sizeDelta.y);
        }

    }
}