using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Trees : MonoBehaviour {

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                PlayerController.OnEnterFSMStateEvent(this, FSMStateType.Jump);

            }
        }
    }
}