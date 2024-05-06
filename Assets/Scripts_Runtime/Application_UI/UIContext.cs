using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS.UIApplication {

    public class UIContext {

        public Panel_Login panel_Login;

        public Canvas canvasOverlay;
        public AssetsManager assets;

        public UIContext() {}

        public void Inject(AssetsManager assets, Canvas canvasOverlay) {
            this.assets = assets;
            this.canvasOverlay = canvasOverlay;
        }

    }

}