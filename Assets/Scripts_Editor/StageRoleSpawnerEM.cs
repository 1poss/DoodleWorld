using System;
using UnityEngine;
using UnityEditor;

namespace DoodleWorldNS.Editor {

    [RequireComponent(typeof(SpriteRenderer))]
    [ExecuteInEditMode]
    public class StageRoleSpawnerEM : MonoBehaviour {

        public RoleTM tm;

        public Vector2 GetPos() {
            return transform.position;
        }

        public float GetRot() {
            return transform.rotation.eulerAngles.z;
        }

        void Update() {
            if (tm == null) {
                return;
            }
            var sr = GetComponent<SpriteRenderer>();
            if (sr.sprite != tm.bodySpr) {
                sr.sprite = tm.bodySpr;
            }
        }

    }

}