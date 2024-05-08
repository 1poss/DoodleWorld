using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class GameDomain {

        public static void EnterStage(GameContext ctx, int chapter, int level) {

            var game = ctx.gameEntity;

            bool has = ctx.assets.Stage_TryGet(chapter, level, out var stageTM);
            if (!has) {
                Debug.LogError($"Stage not found: {chapter}-{level}");
                return;
            }

            // Stage
            var stage = StageDomain.Spawn(ctx, chapter, level);
            ctx.stageRepository.SetCurrent(stage);

            // Roles
            for (int i = 0; i < stageTM.roleSpawners.Length; i++) {
                var spawner = stageTM.roleSpawners[i];
                RoleEntity role = RoleDomain.Spawn(ctx, spawner.typeID, spawner.pos, spawner.rot);
                if (i == 0) {
                    game.ownerRoleID = role.id;
                }
            }

            // Props
            for (int i = 0; i < stageTM.propSpawners.Length; i++) {
                var spawner = stageTM.propSpawners[i];
                PropDomain.Spawn(ctx, spawner.typeID, spawner.pos, spawner.rot);
            }

            game.FSM_Enter_Gaming();
        }

    }

}