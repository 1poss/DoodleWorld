namespace DoodleWorldNS {

    public class GameEntity {

        public GameFSMComponent fsmCom;

        public float fixRestTime;

        public GameEntity() {
            fsmCom = new GameFSMComponent();
            fixRestTime = 0;
        }

        public void FSM_Enter_Login() {
            fsmCom.status = GameFSMStatus.Login;
        }

        public void FSM_Enter_Gaming() {
            fsmCom.status = GameFSMStatus.Gaming;
        }

    }

}