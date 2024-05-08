using UnityEngine;

namespace DoodleWorldNS {

    public class GameContext {

        // ==== Entities ====
        public GameEntity gameEntity;
        public StageRepository stageRepository;
        public RoleRepository roleRepository;
        public PropRepository propRepository;

        // ==== Service ====
        public IDService idService;

        // ==== Infrastructure ====
        public AssetsManager assets;
        public UIManager ui;
        public CameraCore cameraCore;

        public GameContext() {
            gameEntity = new GameEntity();
            stageRepository = new StageRepository();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();

            idService = new IDService();

            assets = new AssetsManager();
            ui = new UIManager();
            cameraCore = new CameraCore();
        }

        public void Inject(Camera mainCamera, Canvas canvasOverlay) {
            ui.Inject(assets, canvasOverlay);
            cameraCore.Inject(mainCamera);
        }

        public RoleEntity Role_GetOwner() {
            RoleEntity role;
            roleRepository.TryGet(gameEntity.ownerRoleID, out role);
            return role;
        }

    }

}