using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class PropEntity : MonoBehaviour {

        public int id;

        public bool isBounce;
        public Vector2 bounceDir;
        public float bounceForce;

        public bool isKey;

        public bool isDoor;
        public bool isDoorOpen;

        public bool isSpike;

        PropMod mod;

        public void Ctor(PropMod mod) {
            this.mod = mod;
        }

        public void Init() {
            if (isKey) {
                mod.Wave_Start();
            }
        }

        public void TearDown() {
            Destroy(gameObject);
        }

        public void Door_Close() {
            if (isDoor) {
                mod.Door_Close();
                isDoorOpen = false;
            }
        }

        public void Door_Open() {
            if (isDoor) {
                mod.Door_Open();
                isDoorOpen = true;
            }
        }

        public void Star_Wave() {
            mod.Wave_Start();
        }

    }

}