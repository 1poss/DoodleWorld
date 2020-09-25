using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Clouds : MonoBehaviour {

        float leftOffX;
        float rightOffX;
        public float moveSpeed;
        float centerX;

        Sequence action;
        Sequence nextAction;

        void Start() {


            centerX = transform.position.x;
            leftOffX = -centerX + -7;
            rightOffX = 38 - centerX;

            action?.Kill();
            action = DOTween.Sequence();
            action.Append(transform.DOMoveX(centerX + rightOffX, (rightOffX) / moveSpeed).SetEase(Ease.Linear));
            // action.Append(transform.DOLocalMoveX(startPos.x, 0));
            // action.Append(transform.DOLocalMoveX(defaultPos.x, (defaultPos.x - startPos.x) / moveSpeed));
            action.AppendCallback(() => {
                transform.position = new Vector3(centerX + leftOffX, transform.localPosition.y);
                nextAction?.Kill();
                nextAction = DOTween.Sequence();
                nextAction.Append(transform.DOMoveX(centerX + rightOffX, (rightOffX - leftOffX) / moveSpeed).SetEase(Ease.Linear));
                nextAction.SetLoops(-1);
            });
        }

        void OnDestroy() {
            action?.Kill();
            nextAction?.Kill();
        }
    }
}