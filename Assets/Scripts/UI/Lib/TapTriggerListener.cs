using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public enum TapType {
        TapDown,
        TapUp,
    }

    public class TapTriggerListener : EventTrigger {

        Action tapDownAction;
        Action tapUpAction;

        public void RegisterTapEvent(TapType type, Action action) {
            switch(type) {
                case TapType.TapDown: this.tapDownAction = action; break;
                case TapType.TapUp: this.tapUpAction = action; break;
            }
        }

        public override void OnPointerDown(PointerEventData e) {
            tapDownAction?.Invoke();
        }

        public override void OnPointerUp(PointerEventData e) {
            tapUpAction?.Invoke();
        }

    }
}