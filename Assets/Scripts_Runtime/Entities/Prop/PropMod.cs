using System;
using System.Collections;
using UnityEngine;
using GameFunctions;

namespace DoodleWorldNS {

    public class PropMod : MonoBehaviour {

        [SerializeField] SpriteRenderer sr;

        [SerializeField] GameObject door_open;
        [SerializeField] GameObject door_close;

        public void Door_Close() {
            door_open.SetActive(false);
            door_close.SetActive(true);
        }

        public void Door_Open() {
            door_open.SetActive(true);
            door_close.SetActive(false);
        }

        void OnDestory() {
            StopAllCoroutines();
        }

        public void Wave_Start() {
            StartCoroutine(Wave_IE());
        }

        IEnumerator Wave_IE() {
            float time = 0;
            Vector2 pos = transform.position;
            sbyte dir = 1;
            while (true) {
                float speed = Time.deltaTime * 2;
                time += speed * dir;
                if ((time >= dir && dir == 1) || (time <= 0 && dir == -1)) {
                    dir *= -1;
                    time = Mathf.Clamp(time, 0, 1);
                }
                transform.position = GFEasing.Ease2D(GFEasingEnum.OutSine, time, 1, pos, pos + new Vector2(0, 0.2f));
                yield return null;
            }
        }
    }

}