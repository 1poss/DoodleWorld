using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BouncePlatform : MonoBehaviour {

        public float bouncePower;
        public Collider2D col;

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {


                Player p = other.gameObject.GetComponent<Player>();
                print(p.rig.velocity.y);
                p.PlatBounce(transform, col, bouncePower);

                AudioController.OnPlaySoundEvent(this, SoundType.PlatformBounce);

            }

        }
    }
}