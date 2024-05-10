using DoodleWorldServer.Businesses;

namespace DoodleWorldServer.Entry {

    public static class ServerMain {

        public static void Main(string[] args) {

            // ==== Instantiate ====
            ServerContext ctx = new ServerContext();

            // ==== Init ====
            ctx.serverEntity.args = args;

            // ==== Enter ====
            ServerBusiness_Startup.Enter(ctx);

        }

    }

}
