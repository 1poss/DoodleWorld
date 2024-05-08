using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Rigidbody2D rb;
        [SerializeField] SpriteRenderer sr;

        public float moveAccelerateSpeed;
        public float moveSpeedMax;
        public float fallingSpeed;
        public float fallingSpeedMax;

        public RoleInputComponent inputCom;
        public RoleFSMComponent fsmCom;

        public Action<RoleEntity, Collision2D> OnCollisionEnterHandle;

        public void Ctor() {
            inputCom = new RoleInputComponent();
            fsmCom = new RoleFSMComponent();
        }

        public void SR_Set(Sprite spr) {
            sr.sprite = spr;
        }

        public void Loco_Move() {
            float x = inputCom.moveAxis * moveAccelerateSpeed;
            Vector2 velo = rb.velocity;
            velo.x = x;
            rb.velocity = velo;
        }

        public void Loco_MoveMustInput(float fixdt) {
            if (inputCom.moveAxis == 0) {
                return;
            }
            float accelerateSpeed = moveAccelerateSpeed;
            Vector2 velo = rb.velocity;
            if (Mathf.Sign(velo.x) != Mathf.Sign(inputCom.moveAxis)) {
                accelerateSpeed *= 2;
            }
            velo.x += inputCom.moveAxis * accelerateSpeed * fixdt;
            velo.x = Mathf.Clamp(velo.x, -moveSpeedMax, moveSpeedMax);
            rb.velocity = velo;

            inputCom.moveAxis = 0;
        }

        public void Loco_Falling(float fixdt) {
            Vector2 velo = rb.velocity;
            velo.y -= fallingSpeed * fixdt;
            if (velo.y < -fallingSpeedMax) {
                velo.y = -fallingSpeedMax;
            }
            rb.velocity = velo;
        }

        public void Bounce(Vector2 jumpForce) {

            Vector2 velo = rb.velocity;
            velo.y = 0;
            rb.velocity = velo;

            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            fsmCom.Bounce_Enter(0.3f);

        }

        void OnCollisionEnter2D(Collision2D other) {
            OnCollisionEnterHandle.Invoke(this, other);
        }

    }

}