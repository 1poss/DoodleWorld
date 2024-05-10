namespace DoodleWorldServer {

    public class ServerContext {

        public ServerEntity serverEntity;

        public RandomService randomService;

        public ServerContext() {
            serverEntity = new ServerEntity();
            randomService = new RandomService();
        }

    }

}