using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class GearSpike : MonoBehaviour {

        Sequence action;
        float rotateGap;
        public Ease inEase;

        [ContextMenu("ReAwake")]
        void Awake() {

            rotateGap = 2f;

            inEase = Ease.InSine;

            action?.Kill();
            action = DOTween.Sequence();
            action.Append(transform.DOLocalRotate(new Vector3(0, 0, 90 * -1), rotateGap).SetEase(inEase));
            action.Append(transform.DOLocalRotate(new Vector3(0, 0, 90 * -2), rotateGap).SetEase(inEase));
            action.Append(transform.DOLocalRotate(new Vector3(0, 0, 90 * -3), rotateGap).SetEase(inEase));
            action.Append(transform.DOLocalRotate(new Vector3(0, 0, 90 * -4), rotateGap).SetEase(inEase));
            action.SetLoops(-1);

        }

        void OnDestroy() {

            action?.Kill();

        }
    }
}