using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class DeadState : FSMStateBase<Player> {

        public override int StateEnum => (int)FSMStateType.Dead;

        public override void Enter(Player actor) {

            // DebugUtil.Log("Enter: " + StateEnum);

            actor.allowControlType = 0
                                    // | ControlType.MOVE
                                    | ControlType.FALLING;

            actor.ResetPhysics();

            // throw new NotImplementedException();

        }

        public override void Execute(Player actor) {

            // actor.allowControlType = 0
                                    // | ControlType.MOVE
                                    // | ControlType.FALLING;

            // throw new NotImplementedException();

        }

        public override void Exit(Player actor) {

            // throw new NotImplementedException();
            
        }

    }
}