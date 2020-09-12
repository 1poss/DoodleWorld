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

        public static event Action<object, EventArgs> PauseEvent;
        public static void OnPauseEvent(object sender, EventArgs args) {
            PauseEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> RestorePauseEvent;
        public static void OnRestorePauseEvent(object sender, EventArgs args) {
            RestorePauseEvent?.Invoke(sender, args);
        }

    }
}