using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Trees : MonoBehaviour {

        public Collider2D col;

        public float bounceForce;

        Vector2 defaultPos;
        public float moveSpeed;
        public float waitTime;
        public Vector2 moveOff;
        Sequence action;

        protected virtual void Awake() {

            col = GetComponent<Collider2D>();

            defaultPos = transform.position;

            if (moveSpeed == 0) {
                moveSpeed = 1;
            }
            moveSpeed = Mathf.Abs(moveSpeed);

            action = DOTween.Sequence();
            action.Append(transform.DOMove(defaultPos + moveOff, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            action.AppendInterval(waitTime);
            action.Append(transform.DOMove(defaultPos, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            action.AppendInterval(waitTime);
            action.SetLoops(-1);

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                // ---- 注释这一段 ----
                // 力的起点
                Vector2 startPos = (Vector2)transform.position + col.offset;

                // 力的方向
                Player p = other.gameObject.GetComponent<Player>();
                Vector2 dir = (Vector2)p.transform.position - startPos;

                // 设置弹力
                p.rig.velocity = dir * bounceForce;
                // -------------------

                p.EnterFSMState(this, FSMStateType.Jump);

            }

        }

        void OnDestroy() {

            action?.Kill();

        }

    }

}