namespace DoodleWorldNS.Domains {

    public static class PlayerDomain {

        public static void Spawn(GameContext ctx) {
            var player = new PlayerEntity();
            player.hp = 5;
            player.hpMax = 5;
            player.gameTime = 0;
            ctx.playerEntity = player;
        }

    }
}