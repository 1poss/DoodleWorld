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

        bool isInit;
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
            Action action = async () => {

                await ctx.assets.Load();
                Application.targetFrameRate = 120;

                // ==== Enter ====
                Business_Login.Enter(ctx);
                isInit = true;

            };

            action.Invoke();

        }

        void Update() {
            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;
            var game = ctx.gameEntity;
            var status = game.fsmCom.status;
            if (status == GameFSMStatus.Login) {
                Business_Login.Tick(ctx, dt);
            } else if (status == GameFSMStatus.Gaming) {
                Business_Game.Tick(ctx, dt);
            } else if (status == GameFSMStatus.GameOver) {
                Business_GameOver.Tick(ctx, dt);
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
            #region Panel_Login
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
            #endregion Panel_Login

            #region Panel_Input
            uiEvents.Input_OnMoveHandle = (moveAxis) => {
                Business_Game.OnUIMove(ctx, moveAxis);
            };
            #endregion Panel_Input

            #region Panel_Lose
            uiEvents.Lose_OnSeeAdHandle = () => {
                Business_Game.RestartStage(ctx);
            };

            uiEvents.Lose_OnRestartHandle = () => {
                Business_Game.ExitGame(ctx);
                Business_Game.NewGame(ctx);
            };
            #endregion Panel_Lose

        }

    }

}