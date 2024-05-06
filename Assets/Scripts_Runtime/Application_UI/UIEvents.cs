using System;
using UnityEngine;

namespace DoodleWorldNS.UIApplication {

    public class UIEvents {

        public Action Login_OnNewGameHandle;
        public void Login_OnNewGame() => Login_OnNewGameHandle.Invoke();

        public Action Login_OnExitHandle;
        public void Login_OnExit() => Login_OnExitHandle.Invoke();

        public UIEvents() { }

    }
}