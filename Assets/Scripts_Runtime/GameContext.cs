using UnityEngine;

namespace DoodleWorldNS {

    public class GameContext {

        public AssetsManager assets;
        public UIManager ui;

        public GameContext() {
            assets = new AssetsManager();
            ui = new UIManager();
        }

        public void Inject(Canvas canvasOverlay) {
            ui.Inject(assets, canvasOverlay);
        }

    }

}