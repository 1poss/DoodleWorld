using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Rigidbody2D rb;
        [SerializeField] SpriteRenderer sr;

        public float moveSpeed;
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
            float x = inputCom.moveAxis * moveSpeed;
            Vector2 velo = rb.velocity;
            velo.x = x;
            rb.velocity = velo;
        }

        public void Loco_MoveByInertia(float fixdt) {
            Vector2 velo = rb.velocity;
            float x = velo.x;
            if (Math.Sign(x) != Math.Sign(inputCom.moveAxis)) {
                x -= moveSpeed * fixdt * 2;
            }
            rb.velocity = new Vector2(x, velo.y);
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
            fsmCom.Bounce_Enter(0.5f);

        }

        void OnCollisionEnter2D(Collision2D other) {
            OnCollisionEnterHandle.Invoke(this, other);
        }

    }

}