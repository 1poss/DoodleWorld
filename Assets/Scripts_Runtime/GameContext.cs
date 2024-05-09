using UnityEngine;

namespace DoodleWorldNS {

    public class GameContext {

        // ==== Entities ====
        public GameEntity gameEntity;
        public PlayerEntity playerEntity;
        public StageRepository stageRepository;
        public RoleRepository roleRepository;
        public PropRepository propRepository;

        // ==== Service ====
        public IDService idService;

        // ==== Infrastructure ====
        public AssetsManager assets;
        public UIManager ui;
        public CameraManager camera;
        public InputManager input;

        public GameContext() {
            gameEntity = new GameEntity();
            stageRepository = new StageRepository();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();

            idService = new IDService();

            assets = new AssetsManager();
            ui = new UIManager();
            camera = new CameraManager();
            input = new InputManager();
        }

        public void Inject(Camera mainCamera, Canvas canvasOverlay) {
            ui.Inject(assets, canvasOverlay);
            camera.Inject(mainCamera);
        }

        public RoleEntity Role_GetOwner() {
            RoleEntity role;
            roleRepository.TryGet(gameEntity.ownerRoleID, out role);
            return role;
        }

        public bool Stage_GetNext(out int chapter, out int level) {
            var stage = stageRepository.GetCurrent();
            return assets.Stage_GetNext(stage.chapter, stage.level, out chapter, out level);
        }

    }

}