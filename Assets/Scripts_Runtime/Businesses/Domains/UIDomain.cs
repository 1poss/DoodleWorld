namespace DoodleWorldNS.Domains {

    public static class UIDomain {

        #region Panel_Lose
        public static void Lose_Open(GameContext ctx) {
            ctx.ui.P_Lose_Open();
        }

        public static void Lose_Close(GameContext ctx) {
            ctx.ui.P_Lose_Close();
        }
        #endregion Panel_Lose

        #region Panel_Input
        public static void Input_Open(GameContext ctx) {
            ctx.ui.P_Input_Open();
        }

        public static void Input_Tick(GameContext ctx, float dt) {
            ctx.ui.P_Input_Tick(dt);
        }

        public static void Input_Close(GameContext ctx) {
            ctx.ui.P_Input_Close();
        }
        #endregion Panel_Input

    }

}