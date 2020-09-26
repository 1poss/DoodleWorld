using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class RandomRainCloud : MonoBehaviour {

        public SpriteRenderer sr;
        float width;

        Sequence action;
        Sequence rainAction;

        void Start() {

            if (sr == null) {
                sr = GetComponent<SpriteRenderer>();
            }

            width = sr.size.x;

            action?.Kill();
            action = DOTween.Sequence();
            float rainGap = 0.5f;
            List<float> posList = new List<float>();
            action.AppendCallback(() => {
                rainAction?.Kill();
                rainAction = DOTween.Sequence();
                posList = GenerateList(posList);
                while(posList.Count > 0) {
                    float pos = posList.Pop();
                    rainAction.AppendCallback(() => {
                        RainSpawner.SpawnRain(transform, (Vector2)transform.position + Vector2.right * pos);
                    });
                    rainAction.AppendInterval(rainGap);
                    rainAction.SetLoops(1);
                }
            });
            action.AppendInterval(rainGap * width + 3f);
            action.SetLoops(-1);

            sr.sprite = null;

        }

        List<float> GenerateList(List<float> posList) {

            if (posList == null) {

                posList = new List<float>();

            }

            posList.Clear();

            for (int i = 0; i < width; i += 1) {
                posList.Add(i);
            }
            posList = posList.Shuffle();
            return posList;

        }

        void OnDestroy() {

            action?.Kill();
            rainAction?.Kill();

        }

        
    }
}