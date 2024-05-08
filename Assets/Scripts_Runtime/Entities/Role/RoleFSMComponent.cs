namespace DoodleWorldNS {

    public class RoleFSMComponent {

        public RoleFSMStatus status;

        public bool normal_isEntering;

        public bool bounce_isEntering;
        public float bounce_maintainTimer;

        public RoleFSMComponent() { }

        public void Normal_Enter() {
            status = RoleFSMStatus.Normal;
            normal_isEntering = true;
        }

        public void Bounce_Enter(float maintainSec) {
            status = RoleFSMStatus.Bounce;
            bounce_isEntering = true;
            bounce_maintainTimer = maintainSec;
        }

    }

}