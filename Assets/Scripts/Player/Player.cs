using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Player : MonoBehaviour {

        public Rigidbody2D rig;
        public FSMBase<Player> fsm;
        public ControlType allowControlType;

        public float moveSpeed;
        public float tendSpeed;

        void Awake() {

            Reset();

            PlayerController.DeadEvent += Dead;
            PlayerController.EatHeartEvent += EatHeart;
            PlayerController.EnterFSMStateEvent += EnterFSMState;

            fsm = new FSMBase<Player>(this);
            fsm.RegisterState(new IdleState());
            fsm.RegisterState(new JumpState());

        }

        public void Reset() {

            rig.velocity = Vector2.zero;
            allowControlType = 0;

            moveSpeed = 5f;
            tendSpeed = 0f;

        }

        protected virtual void FixedUpdate() {

            fsm.Execute();

            if ((allowControlType & ControlType.MOVE) != 0) {

                Move();

            }

            if ((allowControlType & ControlType.MOVE_IN_AIR) != 0) {

                MoveInAir();

            }

            if ((allowControlType & ControlType.FALLING) != 0) {

                Falling();

            }

        }

        #region Controls
        void Move() {

            float xAxis = Input.GetAxisRaw("Horizontal");

            rig.MoveInPlatform(xAxis, moveSpeed);

        }

        void MoveInAir() {

            float xAxis = Input.GetAxisRaw("Horizontal");

            rig.MoveInAir(xAxis, moveSpeed);

        }

        void Falling() {

            rig.Falling(0, -6f);

        }
        #endregion

        #region Exchanges
        public void EnterFSMState(object sender, FSMStateType fsmStateType) {

            fsm.EnterState((int)fsmStateType);

        }

        public void EatHeart(object sender, EventArgs args) {

            print("吃到心");

        }

        public void Dead(object sender, EventArgs args) {

            print("Dead");

        }
        #endregion

    }
}