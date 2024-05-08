using System;
using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class PlayerRoleDomain {

        public static void BakeInput(GameContext ctx, RoleEntity role) {
            var input = ctx.input;
            var inputCom = role.inputCom;
            inputCom.moveAxis = input.moveAxis;
        }
    }
}