using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using DoodleWorldNS.Businesses;

namespace DoodleWorldNS {

    public sealed class Main : MonoBehaviour {

        [SerializeField] Camera mainCamera;
        [SerializeField] Canvas canvasOverlay;

        GameContext ctx;

        bool isTearDown;

        void Awake() {

            DontDestroyOnLoad(gameObject);

            isTearDown = false;

            // ==== Instantiate ====
            ctx = new GameContext();

            // ==== Inject ====
            ctx.Inject(mainCamera, canvasOverlay);

            // ==== Binding ====
            BindingEvents();

            // ==== Init ====
            ctx.assets.Load();
            Application.targetFrameRate = 120;

            // ==== Enter ====
            Business_Login.Enter(ctx);

        }

        void Update() {
            float dt = Time.deltaTime;
            var game = ctx.gameEntity;
            var status = game.fsmCom.status;
            if (status == GameFSMStatus.Login) {
                Business_Login.Tick(ctx, dt);
            } else if (status == GameFSMStatus.Gaming) {
                Business_Game.Tick(ctx, dt);
            }
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void OnDestory() {
            TearDown();
        }

        void TearDown() {

            if (isTearDown) {
                return;
            }
            isTearDown = true;

            ctx.assets.Unload();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

        void BindingEvents() {

            var uiEvents = ctx.ui.Events;
            uiEvents.Login_OnNewGameHandle = () => {
                Business_Login.Exit(ctx);
                Business_Game.NewGame(ctx);
            };

            uiEvents.Login_OnExitHandle = () => {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };

        }

    }

}