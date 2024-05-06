using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DoodleWorldNS {

    public class AssetsManager {

        Dictionary<string, GameObject> uiPrefabs;
        AsyncOperationHandle uiOp;

        public AssetsManager() {
            uiPrefabs = new Dictionary<string, GameObject>();
        }

        public void Load() {
            {
                var op = Addressables.LoadAssetsAsync<GameObject>("UI", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var prefab = list[i];
                    uiPrefabs.Add(prefab.name, prefab);
                }
                this.uiOp = op;
            }
        }

        public void Unload() {
            if (uiOp.IsValid()) {
                Addressables.Release(uiOp);
            }
        }

        public bool TryGetUIPrefab(string name, out GameObject prefab) {
            return uiPrefabs.TryGetValue(name, out prefab);
        }

    }

}