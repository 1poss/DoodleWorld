namespace DoodleWorldNS {

    public class GameEntity {

        public GameFSMComponent fsmCom;

        public int ownerRoleID;
        public int playerHp;

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

        public void FSM_Enter_GameLose() {
            fsmCom.status = GameFSMStatus.GameLose;
        }

        public void FSM_Enter_GameWin() {
            fsmCom.status = GameFSMStatus.GameWin;
        }

    }

}