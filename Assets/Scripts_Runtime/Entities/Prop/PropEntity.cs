using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class PropEntity : MonoBehaviour {

        public int id;

        public PropMod mod;

        public bool isBounce;
        public Vector2 bounceDir;
        public float bounceForce;

        public void Ctor(PropMod mod) {
            this.mod = mod;
        }

    }

}