using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BossNoEyes : MonoBehaviour {

        public Transform shooterTrans;
        public float shootSpeed;

        Sequence action;

        void Start() {

            action = DOTween.Sequence();
            action.AppendCallback(() => {
                BossBullet b = Instantiate(PrefabCollection.Instance.bulletPrefab, transform.parent);
                b.Shoot(shooterTrans, Vector2.left, shootSpeed);
            });
            action.AppendInterval(1.5f);
            action.SetLoops(-1);

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}