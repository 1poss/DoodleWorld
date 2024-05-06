using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using DoodleWorldNS.Businesses;

namespace DoodleWorldNS {

    public sealed class Main : MonoBehaviour {

        [SerializeField] Canvas canvasOverlay;

        GameContext ctx;

        bool isTearDown;

        void Awake() {

            DontDestroyOnLoad(gameObject);

            isTearDown = false;

            // ==== Instantiate ====
            ctx = new GameContext();

            // ==== Inject ====
            ctx.Inject(canvasOverlay);

            // ==== Init ====
            ctx.assets.Load();
            Application.targetFrameRate = 120;

            // ==== Enter ====
            Business_Login.Enter(ctx);

        }

        void Update() {

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

        }

    }

}