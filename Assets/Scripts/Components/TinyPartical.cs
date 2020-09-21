using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TinyPartical : MonoBehaviour {

        static System.Random random;
        float endY;
        float defaultY;
        Sequence action;

        public float bounceForce;
        public Collider2D col;

        void Awake() {

            if (col == null) {

                col = GetComponent<Collider2D>();
                
            }

            defaultY = transform.localPosition.y;
            endY = defaultY + 1;

            if (random == null) {

                random = new System.Random(0);

            }

            int rd = random.Next(2);
            float wait = 0;

            if (rd == 0) {

                wait = 0.45f;

            }

            action = DOTween.Sequence();
            action.AppendInterval(wait);
            action.Append(transform.DOLocalMoveY(endY, 0.45f).SetEase(Ease.OutBack));
            action.Append(transform.DOLocalMoveY(defaultY, 0.45f).SetEase(Ease.InBack));
            action.SetLoops(-1);

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.CircleBounce(transform, col, bounceForce);

            }

        }

        void OnDestroy() {

            action?.Kill();
            
        }
    }
}