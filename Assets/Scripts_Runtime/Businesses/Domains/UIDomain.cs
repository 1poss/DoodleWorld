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

        #region Panel_GameStatus
        public static void GameStatus_Open(GameContext ctx) {
            ctx.ui.P_GameStatus_Open();
            var player = ctx.playerEntity;
            ctx.ui.P_GameStatus_SetHp(player.hp);
        }

        public static void GameStatus_SetTime(GameContext ctx) {
            var player = ctx.playerEntity;
            ctx.ui.P_GameStatus_SetTime(player.gameTime);
        }

        public static void GameStatus_Close(GameContext ctx) {
            ctx.ui.P_GameStatus_Close();
        }
        #endregion Panel_GameStatus

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