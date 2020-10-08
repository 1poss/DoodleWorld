using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BouncePlatform : MonoBehaviour {

        AudioManager audioPlayer;

        public float bouncePower;
        public Collider2D col;

        void Start() {

            audioPlayer = App.Instance.audioPlayer;

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();

                if (p.IsAboveTarget(transform.position, col)) {

                    p.PlatBounce(transform, col, bouncePower);

                }

                audioPlayer.PlaySound(SoundType.PlatformBounce);

            }

        }
    }
}