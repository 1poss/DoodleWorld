using System;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleWorldNS.UIApplication {

    public class Panel_Input : MonoBehaviour {

        [SerializeField] Panel_InputElement leftInputEle;
        [SerializeField] Panel_InputElement rightInputEle;

        public Action<float> OnMoveHandle;

        public void Ctor() {
            leftInputEle.isDown = false;
            rightInputEle.isDown = false;
        }

        public void Tick(float dt) {
            float moveAxis = 0;
            if (leftInputEle.isDown) {
                moveAxis = -1;
            } else if (rightInputEle.isDown) {
                moveAxis = 1;
            }
            OnMoveHandle.Invoke(moveAxis);
        }

        public void Destroy() {
            GameObject.Destroy(gameObject);
        }

    }

}