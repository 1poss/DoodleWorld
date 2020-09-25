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
            action.AppendInterval(gapTime);
            action.AppendCallback(SpawnRain);
            action.SetLoops(-1);

        }

        void SpawnRain() {

            RainSpike rain = Instantiate(PrefabCollection.Instance.rainPrefab, transform);
            rain.Init(transform.position, 1);

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}