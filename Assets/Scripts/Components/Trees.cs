using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Trees : MonoBehaviour {

        static System.Random random;

        public SpriteRenderer sr;
        public Collider2D col;

        public Sprite tree1;
        public Sprite tree2;

        public float bounceForce;

        Vector2 defaultPos;

        public float moveSpeed;
        public float waitTime;
        Vector2 moveOff;
        Sequence action;

        int state;

        bool isAutoMove;

        protected virtual void Awake() {

            if (random == null) {

                random = new System.Random(0);

            }

            int rd = random.Next(2);

            if (rd == 0) {

                sr.sprite = tree1;

            } else {
                
                sr.sprite = tree2;

            }

            isAutoMove = false; // 自动升降

            col = GetComponent<Collider2D>();

            defaultPos = transform.position;

            if (moveSpeed == 0) {
                moveSpeed = 1;
            }
            moveSpeed = Mathf.Abs(moveSpeed);

            state = 0;

            moveOff = new Vector2(0, 1);

            if (isAutoMove) {

                AutoMove();

            }

        }

        void AutoMove() {

            action?.Kill();

            action = DOTween.Sequence();
            action.Append(transform.DOMove(defaultPos + moveOff, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            action.AppendInterval(waitTime);
            action.Append(transform.DOMove(defaultPos, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            action.AppendInterval(waitTime);
            action.SetLoops(-1);

        }

        void ChangeState() {

            action?.Kill();
            action = DOTween.Sequence();

            if (state == 0) {
                state = 1;
                action.Append(transform.DOMove(defaultPos + Vector2.down * 0.1f, 0.1f).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + Vector2.up * 0.1f, 0.1f).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + moveOff * state, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            } else if (state == 1) {
                state = -1;
                action.Append(transform.DOMove(defaultPos + moveOff * state, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + moveOff * state + Vector2.down * 0.1f, 0.1f).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + moveOff * state + Vector2.up * 0.1f, 0.1f).SetEase(Ease.Linear));
            } else if (state == -1) {
                state = 0;
                action.Append(transform.DOMove(defaultPos + Vector2.down * 0.1f, 0.1f).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + Vector2.up * 0.1f, 0.1f).SetEase(Ease.Linear));
                action.Append(transform.DOMove(defaultPos + moveOff * state, moveOff.magnitude / moveSpeed).SetEase(Ease.Linear));
            }

            action.SetLoops(1);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                // ---- 注释这一段 ----
                // 力的起点
                Vector2 startPos = (Vector2)transform.position + col.offset;

                // 力的方向
                Player p = other.gameObject.GetComponent<Player>();
                Vector2 dir = (Vector2)p.transform.position - startPos;

                // 落差
                float heightOff = p.maxHeight - startPos.y;

                // 设置弹力
                p.rig.velocity = dir * (bounceForce + heightOff * 0.3f);

                p.maxHeight = 0;
                // -------------------

                p.EnterFSMState(this, FSMStateType.Jump);

                if (!isAutoMove) {

                    ChangeState();

                }

            }

        }

        void OnDestroy() {

            action?.Kill();

        }

    }

}