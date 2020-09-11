using System;

namespace DoodleWorldNS {

    public static class PlayerController {

        public static event Action<object, EventArgs> DeadEvent;
        public static void OnDeadEvent(object sender, EventArgs args) {
            DeadEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> EatHeartEvent;
        public static void OnEatHeartEvent(object sender, EventArgs args) {
            EatHeartEvent?.Invoke(sender, args);
        }

        public static event Action<object, FSMStateType> EnterFSMStateEvent;
        public static void OnEnterFSMStateEvent(object sender, FSMStateType fsmStateType) {
            EnterFSMStateEvent?.Invoke(sender, fsmStateType);
        }

    }
}