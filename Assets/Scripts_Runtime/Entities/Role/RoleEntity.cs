using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] SpriteRenderer sr;

        public void Ctor() {

        }

        public void SR_Set(Sprite spr) {
            sr.sprite = spr;
        }

    }

}