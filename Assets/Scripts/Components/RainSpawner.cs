using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class RainSpawner : MonoBehaviour {

        [Min(2)]
        public float gapTime;
        Sequence action;

        SpriteRenderer sr;

        void Start() {

            if (sr == null) {
                sr = GetComponent<SpriteRenderer>();
            }
            sr.sprite = null;

            action?.Kill();
            action = DOTween.Sequence();
            action.AppendCallback(() => {
                SpawnRain(transform, transform.position);
            });
            action.AppendInterval(gapTime);
            action.SetLoops(-1);

        }

        public static void SpawnRain(Transform trans, Vector2 stratPos) {

            // print("生成雨: " + stratPos);

            RainSpike rain = Instantiate(PrefabCollection.Instance.rainPrefab, trans);
            rain.Init(stratPos, 1);

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}