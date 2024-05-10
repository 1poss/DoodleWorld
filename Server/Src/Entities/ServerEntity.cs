namespace DoodleWorldServer {

    public class ServerEntity {

        public ServerFSMStatus status;
        public string[] args;
        public WebApplication app;

        public ServerEntity() {
            status = ServerFSMStatus.None;
        }

        public void FSM_Startup_Enter() {
            status = ServerFSMStatus.Startup;
        }

        public void FSM_Running_Enter() {
            status = ServerFSMStatus.Running;
        }

        public void FSM_Shutdown_Enter() {
            status = ServerFSMStatus.Shutdown;
        }

    }

}