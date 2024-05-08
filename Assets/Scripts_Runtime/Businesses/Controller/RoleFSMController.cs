using System;
using UnityEngine;
using DoodleWorldNS.Domains;

namespace DoodleWorldNS.Controllers {

    public static class RoleFSMController {

        public static void FixTick(GameContext ctx, RoleEntity role, float fixdt) {
            var fsm = role.fsmCom;
            var status = fsm.status;
            switch (status) {
                case RoleFSMStatus.Normal:
                    Normal(ctx, role, fixdt);
                    break;
                case RoleFSMStatus.Bounce:
                    Bounce(ctx, role, fixdt);
                    break;
            }
        }

        static void Normal(GameContext ctx, RoleEntity role, float fixdt) {
            var fsm = role.fsmCom;
            if (fsm.normal_isEntering) {
                fsm.normal_isEntering = false;
            }

            role.Loco_Move();
            role.Loco_Falling(fixdt);
        }

        static void Bounce(GameContext ctx, RoleEntity role, float fixdt) {
            var fsm = role.fsmCom;
            if (fsm.bounce_isEntering) {
                fsm.bounce_isEntering = false;
            }

            role.Loco_Move();
            role.Loco_Falling(fixdt);

            fsm.bounce_maintainTimer -= fixdt;
            if (fsm.bounce_maintainTimer <= 0) {
                fsm.Normal_Enter();
            }
        }

    }

}