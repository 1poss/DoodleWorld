using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Door : MonoBehaviour {

        public SpriteRenderer sr;
        public Sprite doorClose;
        public Sprite doorOpen;
        public bool isOpen;
        public string nextLevelUid;

        protected virtual void Awake() {

            if (isOpen) {

                OpenDoor();

            } else {

                CloseDoor();

            }

        }

        public void OpenDoor() {

            isOpen = true;

            sr.sprite = doorOpen;

        }

        public void CloseDoor() {

            isOpen = false;

            sr.sprite = doorClose;

        }

        protected virtual void OnTriggerEnter2D(Collider2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                if (isOpen) {

                    AudioController.OnPlaySoundEvent(this, SoundType.EnterDoor);

                    App.Instance.LoadLevel(nextLevelUid);
                    
                }

            }
        }
        
    }
}