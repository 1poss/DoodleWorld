using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Trees : MonoBehaviour {

        public Collider2D col;

        public float bounceForce;

        protected virtual void Awake() {

            col = GetComponent<Collider2D>();

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                // 力的起点
                Vector2 startPos = (Vector2)transform.position + col.offset;

                // 力的方向
                Player p = other.gameObject.GetComponent<Player>();
                Vector2 dir = (Vector2)p.transform.position - startPos;

                // 设置弹力
                p.rig.velocity = dir.normalized * bounceForce;

                // PlayerController.OnEnterFSMStateEvent(this, FSMStateType.Jump);
                p.EnterFSMState(this, FSMStateType.Jump);

            }

        }

    }

}