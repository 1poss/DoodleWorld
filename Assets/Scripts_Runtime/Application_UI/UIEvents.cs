using System;
using UnityEngine;

namespace DoodleWorldNS.UIApplication {

    public class UIEvents {

        #region Panel_Login
        public Action Login_OnNewGameHandle;
        public void Login_OnNewGame() => Login_OnNewGameHandle.Invoke();

        public Action Login_OnExitHandle;
        public void Login_OnExit() => Login_OnExitHandle.Invoke();
        #endregion Panel_Login

        #region Panel_Input
        public Action<float> Input_OnMoveHandle;
        public void Input_OnMove(float moveAxis) => Input_OnMoveHandle.Invoke(moveAxis);
        #endregion Panel_Input

        #region Panel_Win
        public Action Win_OnConfirmHandle;
        public void Win_OnConfirm() => Win_OnConfirmHandle.Invoke();
        #endregion Panel_Win

        #region Panel_Lose
        public Action Lose_OnSeeAdHandle;
        public void Lose_OnSeeAd() => Lose_OnSeeAdHandle.Invoke();

        public Action Lose_OnRestartHandle;
        public void Lose_OnRestart() => Lose_OnRestartHandle.Invoke();
        #endregion Panel_Lose

        public UIEvents() { }

    }
}