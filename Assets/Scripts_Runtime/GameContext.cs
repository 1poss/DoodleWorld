using UnityEngine;

namespace DoodleWorldNS {

    public class GameContext {

        // ==== Entities ====
        public GameEntity gameEntity;

        // ==== Infrastructure ====
        public AssetsManager assets;
        public UIManager ui;

        public GameContext() {
            gameEntity = new GameEntity();
            assets = new AssetsManager();
            ui = new UIManager();
        }

        public void Inject(Canvas canvasOverlay) {
            ui.Inject(assets, canvasOverlay);
        }

    }

}