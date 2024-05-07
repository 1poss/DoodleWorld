using UnityEngine;

namespace DoodleWorldNS {

    public class GameContext {

        // ==== Entities ====
        public GameEntity gameEntity;
        public RoleRepository roleRepository;
        public PropRepository propRepository;

        // ==== Service ====
        public IDService idService;

        // ==== Infrastructure ====
        public AssetsManager assets;
        public UIManager ui;

        public GameContext() {
            gameEntity = new GameEntity();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();

            idService = new IDService();

            assets = new AssetsManager();
            ui = new UIManager();
        }

        public void Inject(Canvas canvasOverlay) {
            ui.Inject(assets, canvasOverlay);
        }

    }

}