namespace DoodleWorldNS.Domains {

    public static class UIDomain {

        public static void Lose_Open(GameContext ctx) {
            ctx.ui.P_Lose_Open();
        }

        public static void Lose_Close(GameContext ctx) {
            ctx.ui.P_Lose_Close();
        }

    }

}