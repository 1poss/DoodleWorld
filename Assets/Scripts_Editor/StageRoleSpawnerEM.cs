using System;
using UnityEngine;
using UnityEditor;

namespace DoodleWorldNS.Editor {

    [RequireComponent(typeof(SpriteRenderer))]
    [ExecuteInEditMode]
    public class StageRoleSpawnerEM : MonoBehaviour {

        public RoleTM tm;
        public AllyStatus allyStatus;

        public Vector2 GetPos() {
            return transform.localPosition;
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
                this.name = tm.name;
                EditorUtility.SetDirty(this);
            }
        }

    }

}