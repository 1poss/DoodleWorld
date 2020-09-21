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
        public Transform foot;

        public float moveSpeed;
        public float tendSpeed;
        public bool allowHorizental;
        public float fallingGravity;
        public float fallingSpeedMax;
        public float fallingSpeedMaxBase;
        public float maxHeight;

        public int life;
        public int lifeMax;

        Camera cam;

        #region Pause
        Vector2 preVec;
        FSMBase<Player> preFSM;
        bool isPause;
        #endregion

        void Awake() {

            fsm = new FSMBase<Player>(this);
            fsm.RegisterState(new IdleState());
            fsm.RegisterState(new JumpState());
            fsm.RegisterState(new DeadState());

            ResetPhysics();

            InitValue();

            PlayerController.DeadEvent += Dead;
            PlayerController.EatHeartEvent += EatHeart;
            PlayerController.EnterFSMStateEvent += EnterFSMState;
            PlayerController.PauseEvent += Pause;
            PlayerController.RestorePauseEvent += RestorePause;

            cam = Camera.main;

        }

        public void InitValue() {

            lifeMax = 3;
            life = lifeMax;
            maxHeight = 0;
            rig.velocity = Vector2.zero;

        }

        public void ResetPhysics() {

            // 重置控制
            isPause = false;
            allowHorizental = true;
            allowControlType = 0;

            // 重置物理
            rig.velocity = Vector2.zero;
            maxHeight = 0;
            moveSpeed = 4.2f;
            tendSpeed = 0f;
            fallingGravity = -6f;
            fallingSpeedMaxBase = 14f;
            fallingSpeedMax = fallingSpeedMaxBase;

            EnterFSMState(this, FSMStateType.Idle);
            
        }

        protected virtual void Update() {

            if (fsm != null) {

                if (fsm.currentState.StateEnum != (int)FSMStateType.Dead) {

                    bool escKey = Input.GetKeyUp(KeyCode.Escape);

                    if (escKey) {

                        Pause(this, EventArgs.Empty);
                        UIController.OnPopupPauseEvent(this, EventArgs.Empty);

                    }

                }

            }

        }

        protected virtual void FixedUpdate() {

            if (isPause) {
                return;
            }

            // 相机跟随
            Level currentLevel = App.Instance.currentLevel;

            if (currentLevel != null) {

                cam.FollowTargetLimited(false, transform.position, currentLevel.mapBorder.borderTilemap, currentLevel.mapBorder.bounds, ConfigCollection.cameraOffset);

            }

            fsm.Execute();

            FallingWithRaise();

            if ((allowControlType & ControlType.MOVE) != 0) {

                Move();

            }

            if ((allowControlType & ControlType.MOVE_IN_AIR) != 0 && allowHorizental) {

                MoveInAir();

            }

            if ((allowControlType & ControlType.FALLING) != 0) {

                Falling();

            }

            if (transform.position.y > maxHeight) {

                maxHeight = transform.position.y;

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

            rig.Falling(0, fallingGravity);

            if (rig.velocity.y < -fallingSpeedMax) {

                rig.velocity = new Vector2(rig.velocity.x, -fallingSpeedMax);

            }

        }

        void FallingWithRaise() {

            float raiseAxis = Input.GetAxisRaw("Jump");

            if (raiseAxis == 0) {

                // fallingSpeedMax = fallingSpeedMaxBase;

            } else {

                // fallingSpeedMax = fallingSpeedMaxBase * 2f;

                rig.velocity = new Vector2(0, -fallingSpeedMax);

            }

        }

        public void PlatBounce(Transform here, Collider2D col, float force) {

            fallingSpeedMax = fallingSpeedMaxBase;

            Vector2 startPos = (Vector2)here.position + col.offset;

            if (foot.position.y <= startPos.y) {

                return;

            }

            Vector2 dir = (Vector2)foot.position - startPos;

            float heightOff = maxHeight - startPos.y;

            rig.velocity = new Vector2(0, force);

            maxHeight = 0;
            
        }

        public void CircleBounce(Transform here, Collider2D col, float force) {

            fallingSpeedMax = fallingSpeedMaxBase;

            // 力的起点
            Vector2 startPos = (Vector2)here.position + col.offset;

            // 弹
            rig.CircleBounce(startPos, force);

            maxHeight = 0;

            AudioController.OnPlaySoundEvent(this, SoundType.TreeBounce);

            allowHorizental = false;

            EnterFSMState(typeof(Effect), FSMStateType.Jump);

        }
        #endregion

        #region Exchanges
        public void EnterFSMState(object sender, FSMStateType fsmStateType) {

            fsm.EnterState((int)fsmStateType);

        }

        public void EatHeart(object sender, EventArgs args) {

            life += 1;
            if (life >= lifeMax) {
                life = lifeMax;
            }

            UIController.OnAddLifeEvent(this, new AddLifeEventArgs(this, 1));

        }

        public void Dead(object sender, EventArgs args) {

            life -= 1;

            UIController.OnReduceLifeEvent(this, new ReduceLifeEventArgs(this, 1));

            if (life <= 0) {

                ResetPhysics();

                EnterFSMState(this, FSMStateType.Dead);

                UIController.OnPopupGameOverEvent(this, EventArgs.Empty);

            } else {

                LevelController.OnReloadLevelEvent(this, this);

            }

            AudioController.OnPlaySoundEvent(this, SoundType.Dead);

        }

        public void Pause(object sender, EventArgs args) {

            isPause = true;
            preVec = rig.velocity;

            rig.velocity = Vector2.zero;

        }

        public void RestorePause(object sender, EventArgs args) {

            isPause = false;
            rig.velocity = preVec;

        }
        #endregion

    }
}