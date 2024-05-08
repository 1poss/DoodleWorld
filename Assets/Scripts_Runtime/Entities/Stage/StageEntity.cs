using System;
using UnityEngine;

namespace DoodleWorldNS {

    public class StageEntity : MonoBehaviour {

        public int id;

        public int chapter;
        public int level;

        public Vector2 size;

        public void Ctor() {

        }

        public bool IsOutofStage(Vector2 pos) {
            Vector2 min = (Vector2)transform.position - Vector2.up * 2;
            Vector2 max = min + size;
            return pos.y < min.y;
        }

    }

}