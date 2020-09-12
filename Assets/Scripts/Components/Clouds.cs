using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Clouds : MonoBehaviour {

        public float startX;
        public float endX;
        public float moveSpeed;
        Vector2 defaultPos;

        Sequence action;
        Sequence nextAction;

        void Awake() {

            defaultPos = transform.position;

            action?.Kill();
            action = DOTween.Sequence();
            action.Append(transform.DOLocalMoveX(endX, (endX - defaultPos.x) / moveSpeed).SetEase(Ease.Linear));
            // action.Append(transform.DOLocalMoveX(startPos.x, 0));
            // action.Append(transform.DOLocalMoveX(defaultPos.x, (defaultPos.x - startPos.x) / moveSpeed));
            action.AppendCallback(() => {
                transform.localPosition = new Vector3(startX, transform.localPosition.y);
                nextAction?.Kill();
                nextAction = DOTween.Sequence();
                nextAction.Append(transform.DOLocalMoveX(endX, (endX - startX) / moveSpeed).SetEase(Ease.Linear));
                nextAction.SetLoops(-1);
            });
        }

        void OnDestroy() {
            action?.Kill();
            nextAction?.Kill();
        }
    }
}