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

        public void Shoot(Transform startTrans, Vector2 dir, float moveSpeed) {

            transform.position = startTrans.position;
            defaultPos = transform.position;

            rig.velocity = dir * moveSpeed;
            
        }

        void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.CircleBounce(transform, col, bounceForce);

                Destroy(gameObject);

            }

        }

        void OnDestroy() {

        }

    }
}