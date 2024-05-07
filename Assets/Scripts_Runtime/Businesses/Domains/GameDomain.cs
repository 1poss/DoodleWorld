using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class GameDomain {

        public static void EnterStage(GameContext ctx, int chapter, int level) {

            bool has = ctx.assets.Stage_TryGet(chapter, level, out var stage);
            if (!has) {
                Debug.LogError($"Stage not found: {chapter}-{level}");
                return;
            }

            // Roles
            for (int i = 0; i < stage.roleSpawners.Length; i++) {
                var spawner = stage.roleSpawners[i];
                RoleDomain.Spawn(ctx, spawner.typeID, spawner.pos, spawner.rot);
            }

            // Props
            for (int i = 0; i < stage.propSpawners.Length; i++) {
                var spawner = stage.propSpawners[i];
                PropDomain.Spawn(ctx, spawner.typeID, spawner.pos, spawner.rot);
            }

            ctx.gameEntity.FSM_Enter_Gaming();
        }

    }

}