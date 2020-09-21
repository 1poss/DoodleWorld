using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class GearSpike : MonoBehaviour {

        Sequence action;

        void Awake() {

            action?.Kill();
            action = DOTween.Sequence();
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 1), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 2), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 3), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 4), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 5), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 6), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 7), 0.2f));
            action.Append(transform.DORotateQuaternion(new Quaternion(0, 0, 0, 45 * 8), 0.2f));
            action.SetLoops(-1);

        }

        void OnDestroy() {

            action?.Kill();

        }
    }
}