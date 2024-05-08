using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS.UIApplication {

    public class UIContext {

        public Panel_Login panel_Login;
        public Panel_Lose panel_Lose;
        public Panel_Input panel_Input;

        public UIEvents events;

        public Canvas canvasOverlay;

        // ==== External ====
        public AssetsManager assets;

        public UIContext() {
            events = new UIEvents();
        }

        public void Inject(AssetsManager assets, Canvas canvasOverlay) {
            this.assets = assets;
            this.canvasOverlay = canvasOverlay;
        }

    }

}