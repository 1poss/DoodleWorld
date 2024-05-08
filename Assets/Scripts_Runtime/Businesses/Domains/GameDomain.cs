using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class GameDomain {

        public static void TryEnterNextStage(GameContext ctx) {
            bool hasNext = ctx.Stage_GetNext(out var nextChapter, out var nextLevel);
            if (hasNext) {
                CleanStage(ctx);
                EnterStage(ctx, nextChapter, nextLevel);
            } else {
                Debug.Log("Finish Game");
            }
        }

        public static void EnterStage(GameContext ctx, int chapter, int level) {

            var game = ctx.gameEntity;

            bool has = ctx.assets.Stage_TryGet(chapter, level, out var stageTM);
            if (!has) {
                Debug.LogError($"Stage not found: {chapter}-{level}");
                return;
            }

            // Stage
            var stage = StageDomain.Spawn(ctx, chapter, level);
            Vector2 stagePos = stage.transform.position;
            ctx.stageRepository.SetCurrent(stage);

            // Roles
            for (int i = 0; i < stageTM.roleSpawners.Length; i++) {
                var spawner = stageTM.roleSpawners[i];
                RoleEntity role = RoleDomain.Spawn(ctx, spawner.typeID, spawner.allyStatus, spawner.pos + stagePos, spawner.rot);
                if (role.allyStatus == AllyStatus.Player) {
                    game.ownerRoleID = role.id;
                }
            }

            // Props
            for (int i = 0; i < stageTM.propSpawners.Length; i++) {
                var spawner = stageTM.propSpawners[i];
                PropDomain.Spawn(ctx, spawner.typeID, spawner.pos + stagePos, spawner.rot);
            }

            // UI
            UIDomain.Input_Open(ctx);
            UIDomain.GameStatus_Open(ctx);

            game.FSM_Enter_Gaming();

        }

        public static void CleanStage(GameContext ctx) {
            // Clean Roles
            {
                int roleLen = ctx.roleRepository.TakeAll(out var roles);
                for (int i = 0; i < roleLen; i++) {
                    var role = roles[i];
                    role.TearDown();
                }
                ctx.roleRepository.Clear();
            }

            // Clean Props
            {
                int propLen = ctx.propRepository.TakeAll(out var props);
                for (int i = 0; i < propLen; i++) {
                    var prop = props[i];
                    prop.TearDown();
                }
                ctx.propRepository.Clear();
            }

            // Clean Stage
            {
                var stage = ctx.stageRepository.GetCurrent();
                GameObject.Destroy(stage.gameObject);
                ctx.stageRepository.Clear();
            }

            // UI
            UIDomain.Input_Close(ctx);
            UIDomain.Lose_Close(ctx);
            UIDomain.GameStatus_Close(ctx);

        }

        public static void Lose(GameContext ctx) {
            ctx.playerEntity.hp--;
            UIDomain.Lose_Open(ctx);
        }

    }

}