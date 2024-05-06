using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DoodleWorldNS.UIApplication;

namespace DoodleWorldNS {

    public sealed class UIManager {

        UIContext ctx;

        public UIManager() {
            ctx = new UIContext();
        }

        public void Inject(AssetsManager assets, Canvas canvasOverlay) {
            ctx.Inject(assets, canvasOverlay);
        }

        public void Init() {

        }

        #region Panel_Login
        public void P_Login_Open() {
            var panel = ctx.panel_Login;
            if (panel == null) {
                panel = Open<Panel_Login>();
                panel.Ctor();
                panel.OnStartHandle = () => {
                    Debug.Log("Start Game");
                };
                panel.OnExitHandle = () => {
                    Debug.Log("Exit Game");
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

        T Open<T>() where T : MonoBehaviour {
            string name = typeof(T).Name;
            bool has = ctx.assets.TryGetUIPrefab(name, out var prefab);
            if (!has) {
                Debug.LogError($"UI prefab not found: {name}");
                return null;
            }
            var go = GameObject.Instantiate(prefab, ctx.canvasOverlay.transform);
            return go.GetComponent<T>();
        }

    }

}