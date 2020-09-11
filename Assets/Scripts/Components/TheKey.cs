using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TheKey : MonoBehaviour {

        public UnityEvent eventAction;

        protected virtual void OnTriggerEnter2D(Collider2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Destroy(gameObject);

                eventAction?.Invoke();

            }

        }
    }
}