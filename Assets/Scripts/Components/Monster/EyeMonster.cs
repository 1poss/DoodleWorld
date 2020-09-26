using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class EyeMonster : MonoBehaviour {

        public Transform head;
        public Collider2D col;
        public Transform shooter;

        public float shootSpeed;
        Sequence action;

        void Start() {

            action = DOTween.Sequence();
            action.AppendCallback(() => {
                BossBullet b = Instantiate(PrefabCollection.Instance.bulletPrefab, transform);
                b.Shoot(shooter, (Vector2)shooter.position - ((Vector2)head.position + col.offset), shootSpeed);
            });
            action.AppendInterval(1.5f);
            action.SetLoops(-1);

        }

        void OnDestroy() {

            action?.Kill();

        }


    }
}