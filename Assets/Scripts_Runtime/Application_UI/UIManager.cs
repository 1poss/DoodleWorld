using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DoodleWorldNS.UIApplication;

namespace DoodleWorldNS {

    public sealed class UIManager {

        UIContext ctx;

        public UIEvents Events => ctx.events;

        public UIManager() {
            ctx = new UIContext();
        }

        public void Inject(AssetsManager assets, Canvas canvasOverlay) {
            ctx.Inject(assets, canvasOverlay);
        }

        #region Panel_Login
        public void P_Login_Open() {
            var panel = ctx.panel_Login;
            if (panel == null) {
                panel = Open<Panel_Login>();
                panel.Ctor();
                panel.OnNewGameHandle = () => {
                    ctx.events.Login_OnNewGame();
                };
                panel.OnExitHandle = () => {
                    ctx.events.Login_OnExit();
                };
                ctx.panel_Login = panel;
            }
        }

        public void P_Login_Close() {
            var panel = ctx.panel_Login;
            panel?.TearDown();
            ctx.panel_Login = null;
        }
        #endregion Panel_Login

        #region Panel_Input
        public void P_Input_Open() {
            var panel = ctx.panel_Input;
            if (panel == null) {
                panel = Open<Panel_Input>();
                panel.Ctor();
                panel.OnMoveHandle = (moveAxis) => {
                    ctx.events.Input_OnMove(moveAxis);
                };
                ctx.panel_Input = panel;
            }
        }

        public void P_Input_Tick(float dt) {
            var panel = ctx.panel_Input;
            panel?.Tick(dt);
        }

        public void P_Input_Close() {
            var panel = ctx.panel_Input;
            panel?.TearDown();
            ctx.panel_Input = null;
        }
        #endregion Panel_Input

        #region Panel_GameStatus
        public void P_GameStatus_Open() {
            var panel = ctx.panel_GameStatus;
            if (panel == null) {
                panel = Open<Panel_GameStatus>();
                panel.Ctor();
                ctx.panel_GameStatus = panel;
            }
        }

        public void P_GameStatus_SetHp(int hp) {
            var panel = ctx.panel_GameStatus;
            panel?.SetHp(hp);
        }

        public void P_GameStatus_SetTime(float time) {
            var panel = ctx.panel_GameStatus;
            panel?.SetTime(time);
        }

        public void P_GameStatus_Close() {
            var panel = ctx.panel_GameStatus;
            panel?.TearDown();
            ctx.panel_GameStatus = null;
        }
        #endregion Panel_GameStatus

        #region Panel_Win
        public void P_Win_Open() {
            var panel = ctx.panel_Win;
            if (panel == null) {
                panel = Open<Panel_Win>();
                panel.Ctor();
                panel.OnWinConfirmHandle = () => {
                    ctx.events.Win_OnConfirm();
                };
                ctx.panel_Win = panel;
            }
        }

        public void P_Win_SetTime(float time) {
            var panel = ctx.panel_Win;
            panel?.SetTime(time);
        }

        public void P_Win_Close() {
            var panel = ctx.panel_Win;
            panel?.TearDown();
            ctx.panel_Win = null;
        }
        #endregion Panel_Win

        #region Panel_Lose
        public void P_Lose_Open() {
            var panel = ctx.panel_Lose;
            if (panel == null) {
                panel = Open<Panel_Lose>();
                panel.Ctor();
                panel.OnSeeAdHandle = () => {
                    ctx.events.Lose_OnSeeAd();
                };
                panel.OnRestartHandle = () => {
                    ctx.events.Lose_OnRestart();
                };
                ctx.panel_Lose = panel;
            }
        }

        public void P_Lose_Close() {
            var panel = ctx.panel_Lose;
            panel?.TearDown();
            ctx.panel_Lose = null;
        }
        #endregion Panel_Lose

        T Open<T>() where T : MonoBehaviour {
            string name = typeof(T).Name;
            bool has = ctx.assets.UI_TryGet(name, out var prefab);
            if (!has) {
                Debug.LogError($"UI prefab not found: {name}");
                return null;
            }
            var go = GameObject.Instantiate(prefab, ctx.canvasOverlay.transform);
            return go.GetComponent<T>();
        }

    }

}