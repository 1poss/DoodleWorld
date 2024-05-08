using System;
using UnityEngine;
using UnityEditor;
using GameFunctions;

namespace DoodleWorldNS.Editor {

    [ExecuteInEditMode]
    public class StageEM : MonoBehaviour {

        [SerializeField] StageTM tm;

        [SerializeField] Vector2 size;

        [GFButton("Save")]
        public void Save() {
            {
                tm.size = size;
            }

            {
                var propSpawners = GetComponentsInChildren<StagePropSpawnerEM>();
                tm.propSpawners = new StagePropSpawnerTM[propSpawners.Length];
                for (int i = 0; i < propSpawners.Length; i++) {
                    tm.propSpawners[i] = new StagePropSpawnerTM {
                        pos = propSpawners[i].GetPos(),
                        rot = propSpawners[i].GetRot(),
                        typeID = propSpawners[i].tm.typeID
                    };
                }
            }

            {
                var roleSpawners = GetComponentsInChildren<StageRoleSpawnerEM>();
                tm.roleSpawners = new StageRoleSpawnerTM[roleSpawners.Length];
                for (int i = 0; i < roleSpawners.Length; i++) {
                    tm.roleSpawners[i] = new StageRoleSpawnerTM {
                        pos = roleSpawners[i].GetPos(),
                        rot = roleSpawners[i].GetRot(),
                        typeID = roleSpawners[i].tm.typeID
                    };
                }
            }

            EditorUtility.SetDirty(tm);

        }

        void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Vector3 halfSize = size / 2;
            Gizmos.DrawWireCube(transform.position + halfSize, new Vector3(size.x, size.y));
        }

    }

}