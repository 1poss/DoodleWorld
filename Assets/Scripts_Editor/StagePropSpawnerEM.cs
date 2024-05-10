using System;
using UnityEngine;
using UnityEditor;

namespace DoodleWorldNS.Editor {

    [RequireComponent(typeof(SpriteRenderer))]
    [ExecuteInEditMode]
    public class StagePropSpawnerEM : MonoBehaviour {

        public PropTM tm;

        public Vector2 GetPos() {
            return transform.localPosition;
        }

        public float GetRot() {
            return transform.rotation.eulerAngles.z;
        }

        void Update() {
            if (tm == null || tm.modPrefab == null) {
                return;
            }
            var mod = transform.Find("Mod");
            if (mod == null) {
                var go = GameObject.Instantiate(tm.modPrefab, transform);
                go.name = "Mod";
                EditorUtility.SetDirty(this);
            }
            if (this.name != tm.propName) {
                this.name = tm.propName;
                EditorUtility.SetDirty(this);
            }
        }

    }

}