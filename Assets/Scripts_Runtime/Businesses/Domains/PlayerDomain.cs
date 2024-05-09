namespace DoodleWorldNS.Domains {

    public static class PlayerDomain {

        public static void Spawn(GameContext ctx) {
            var player = new PlayerEntity();
            player.hp = 3;
            player.gameTime = 0;
            ctx.playerEntity = player;
        }

    }
}