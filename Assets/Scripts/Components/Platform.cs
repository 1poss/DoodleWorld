using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Platform : MonoBehaviour {

        Collider2D col;
        float bouncePower;

        void Awake() {

            col = GetComponent<Collider2D>();
            bouncePower = 9;

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            // if (other.gameObject.tag == TagCollection.PLAYER) {

            //     Player p = other.gameObject.GetComponent<Player>();
            //     p.EnterFSMState(this, FSMStateType.Idle);

            //     AudioController.OnPlaySoundEvent(this, SoundType.PlatformBounce);

            // }

            if (other.gameObject.tag == TagCollection.PLAYER) {


                Player p = other.gameObject.GetComponent<Player>();
                p.PlatBounce(transform, col, bouncePower);

                AudioController.OnPlaySoundEvent(this, SoundType.PlatformBounce);

            }

        }
    }
}