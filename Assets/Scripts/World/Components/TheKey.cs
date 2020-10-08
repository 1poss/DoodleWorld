using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TheKey : MonoBehaviour {

        AudioManager audioPlayer;

        public UnityEvent eventAction;

        void Start() {

            audioPlayer = App.Instance.audioPlayer;
            
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                audioPlayer.PlaySound(SoundType.Gather);

                Destroy(gameObject);

                eventAction?.Invoke();

            }

        }
    }
}