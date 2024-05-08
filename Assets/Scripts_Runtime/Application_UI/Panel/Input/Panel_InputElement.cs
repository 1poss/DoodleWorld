using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DoodleWorldNS.UIApplication {

    public class Panel_InputElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        public bool isDown;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
            isDown = true;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
            isDown = false;
        }

    }

}