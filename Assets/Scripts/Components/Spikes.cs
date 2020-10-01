using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Spikes : MonoBehaviour {

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.Dead();

            }

        }

    }
}