using UnityEngine;

namespace DoodleWorldNS.Businesses {

    public static class Business_Game {

        public static void NewGame(GameContext ctx) {
            Debug.Log("New Game");
            ctx.gameEntity.FSM_Enter_Gaming();
        }

        public static void Tick(GameContext ctx, float dt) {

            // ==== Pre Logic ====

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

            Physics2D.Simulate(fixdt);
        }

        static void LateTick(GameContext ctx, float dt) {

        }

    }

}