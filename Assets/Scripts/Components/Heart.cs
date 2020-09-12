using System;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Heart : MonoBehaviour {

        protected virtual void OnTriggerEnter2D(Collider2D other) {

            if (other.tag == TagCollection.PLAYER) {

                AudioController.OnPlaySoundEvent(this, SoundType.Gather);
                
                PlayerController.OnEatHeartEvent(this, EventArgs.Empty);
                
                Destroy(gameObject);

            }
        }
    }
}