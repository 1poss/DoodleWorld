using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] SpriteRenderer sr;

        public RoleInputComponent inputCom;

        public void Ctor() {
            inputCom = new RoleInputComponent();
        }

        public void SR_Set(Sprite spr) {
            sr.sprite = spr;
        }

    }

}