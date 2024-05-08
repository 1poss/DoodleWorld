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
            panel?.Destory();
            ctx.panel_Login = null;
        }
        #endregion Panel_Login

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
            panel?.Destroy();
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