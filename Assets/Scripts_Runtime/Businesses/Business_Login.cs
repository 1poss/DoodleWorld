namespace DoodleWorldNS.Businesses {

    public static class Business_Login {

        public static void Enter(GameContext ctx) {
            ctx.ui.P_Login_Open();
            ctx.gameEntity.FSM_Enter_Login();
        }

        public static void Exit(GameContext ctx) {
            ctx.ui.P_Login_Close();
        }

        public static void Tick(GameContext ctx, float dt) {

        }

    }

}