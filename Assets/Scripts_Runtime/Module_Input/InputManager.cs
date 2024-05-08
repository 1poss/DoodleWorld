using UnityEngine;

namespace DoodleWorldNS {

    public class InputManager {

        sbyte mode; // 0 keyboard, 1 touch
        public float moveAxis;

        public InputManager() {
#if UNITY_ANDROID || UNITY_IOS
            mode = 1;
#else
            mode = 0;
#endif
        }

        public void Tick(float dt) {
            if (mode == 0) {
                moveAxis = Input.GetAxis("Horizontal");
            }
        }

        public void SetKeyboardMode() {
            mode = 0;
        }

        public void SetTouchMode() {
            mode = 1;
        }

        public void Touch_SetMoveAxis(float axis) {
            moveAxis = axis;
        }

    }

}