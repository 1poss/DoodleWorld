using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BossBullet : MonoBehaviour {

        public Rigidbody2D rig;
        public Collider2D col;
        public float bounceForce;

        Vector2 defaultPos;
        Sequence action;

        public void Shoot(Transform startTrans, Vector2 dir, float moveSpeed) {

            transform.position = startTrans.position;
            defaultPos = transform.position;

            rig.velocity = dir * moveSpeed;
            transform.rotation = dir.To2DFaceRotation();
            
            action = DOTween.Sequence();
            action.AppendInterval(5f);
            action.AppendCallback(() => {
                Destroy(gameObject);
            });
            action.SetLoops(1);
            
        }

        void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();

                if (p.IsAboveTarget((Vector2)transform.position + Vector2.down, col)) {

                    p.PlatBounce(transform, col, bounceForce);

                }

                Destroy(gameObject);

            } else if (other.gameObject.tag == TagCollection.AIR_WALL) {

                print("Col AirWall");

                Destroy(gameObject);

            }

        }

        void OnDestroy() {

            action?.Kill();

        }

    }
}