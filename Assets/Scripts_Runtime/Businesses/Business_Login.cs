using DoodleWorldNS.Domains;

namespace DoodleWorldNS.Businesses {

    public static class Business_Login {

        public static void Enter(GameContext ctx) {
            UIDomain.Login_Open(ctx);
            ctx.gameEntity.FSM_Enter_Login();
        }

        public static void Exit(GameContext ctx) {
            UIDomain.Login_Close(ctx);
        }

        public static void Tick(GameContext ctx, float dt) {

        }

    }

}