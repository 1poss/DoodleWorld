using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class PropEntity : MonoBehaviour {

        public int id;

        public PropMod mod;

        public void Ctor(PropMod mod) {
            this.mod = mod;
        }

    }

}