using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Trees : MonoBehaviour {

        static System.Random random;

        public SpriteRenderer sr;

        public Sprite tree1;
        public Sprite tree2;

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