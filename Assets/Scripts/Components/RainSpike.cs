using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class RainSpike : MonoBehaviour {

        public Rigidbody2D rig;
        Sequence action;

        void Start() {

            if (rig == null) {
                rig = GetComponent<Rigidbody2D>();
            }

        }

        public void Init(Vector2 stratPos, float gravityScale) {

            transform.position = stratPos;

            rig.velocity = Vector2.zero;
            
            action?.Kill();
            action = DOTween.Sequence();
            action.AppendInterval(1f);
            action.AppendCallback(() => {
                float scale = gravityScale;
                rig.gravityScale = scale;
                action?.Kill();
            });
            action.SetLoops(1);

        }

        void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.Dead(this, EventArgs.Empty);
                Destroy(gameObject);

            } else {

                Destroy(gameObject);

            }

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}