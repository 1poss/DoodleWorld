using UnityEngine;
using DoodleWorldNS.Domains;
using DoodleWorldNS.Controllers;

namespace DoodleWorldNS.Businesses {

    public static class Business_Game {

        public static void NewGame(GameContext ctx) {
            const int newGameChapter = 1;
            const int newGameLevel = 1;
            GameDomain.EnterStage(ctx, newGameChapter, newGameLevel);
        }

        public static void Tick(GameContext ctx, float dt) {

            // ==== Pre Logic ====
            ctx.input.Tick(dt);

            var owner = ctx.Role_GetOwner();
            PlayerRoleDomain.BakeInput(ctx, owner);

            // ==== Fix Logic ====
            ref var fixRestTime = ref ctx.gameEntity.fixRestTime;
            fixRestTime += dt;
            const float fixInterval = 0.02f;
            if (fixRestTime < fixInterval) {
                FixTick(ctx, fixRestTime);
                fixRestTime = 0;
            } else {
                while (fixRestTime >= fixInterval) {
                    FixTick(ctx, fixInterval);
                    fixRestTime -= fixInterval;
                }
            }

            // ==== Late Logic ====
            LateTick(ctx, dt);

        }

        static void FixTick(GameContext ctx, float fixdt) {

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i++) {
                var role = roles[i];
                RoleFSMController.FixTick(ctx, role, fixdt);
            }

            Physics2D.Simulate(fixdt);

        }

        static void LateTick(GameContext ctx, float dt) {
            var owner = ctx.Role_GetOwner();
            var stage = ctx.stageRepository.GetCurrent();
            ctx.camera.Follow(owner.transform.position, stage.transform.position, stage.size);
        }

    }

}