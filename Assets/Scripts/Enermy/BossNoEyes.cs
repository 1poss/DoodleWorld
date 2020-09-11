using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BossNoEyes : MonoBehaviour {

        public Transform shooterTrans;
        public BossBullet bulletPrefab;
        public Collider2D col;
        public float bounceForce;
        public float shootSpeed;

        Sequence action;

        void Awake() {

            action = DOTween.Sequence();
            action.AppendCallback(() => {
                BossBullet b = Instantiate(bulletPrefab, transform.parent);
                b.Shoot(shooterTrans, Vector2.left, shootSpeed);
            });
            action.AppendInterval(1.5f);
            action.SetLoops(-1);

        }

        void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.Bounce(transform, col, bounceForce);

            }

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}