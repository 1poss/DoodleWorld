using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public static class Effect {

        public static void BouncePlayer(Transform here, Collider2D col, Player player, float force) {

            // 力的起点
            Vector2 startPos = (Vector2)here.position + col.offset;

            // 力的方向
            Vector2 dir = (Vector2)player.transform.position - startPos;

            // 落差
            float heightOff = player.maxHeight - startPos.y;

            // 设置弹力
            player.rig.velocity = dir * (force + heightOff * 0.45f);

            player.maxHeight = 0;

            player.EnterFSMState(typeof(Effect), FSMStateType.Jump);

        }

    }
}