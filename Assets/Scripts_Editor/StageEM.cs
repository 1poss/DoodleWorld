using System;
using UnityEngine;
using UnityEditor;
using TriInspector;

namespace DoodleWorldNS.Editor {

    public class StageEM : MonoBehaviour {

        [SerializeField] StageTM tm;

        [Button]
        void Save() {

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

    }

}