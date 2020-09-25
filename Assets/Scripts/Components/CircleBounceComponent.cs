using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class CircleBounceComponent : MonoBehaviour {

        public float bounceForce;
        public Collider2D col;

        void Awake() {

            if (col == null) {
                col = GetComponent<Collider2D>();
            }
        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.CircleBounce(transform, col, bounceForce);

            }

        }
    }
}