using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DoodleWorldNS {

    public class AssetsManager {

        Dictionary<string, GameObject> entityPrefabs;
        AsyncOperationHandle entityOp;

        Dictionary<string, GameObject> uiPrefabs;
        AsyncOperationHandle uiOp;

        Dictionary<int, RoleTM> roleTMs;
        AsyncOperationHandle roleTMOp;

        Dictionary<int, PropTM> propTMs;
        AsyncOperationHandle propTMOp;

        Dictionary<ulong, StageTM> stageTMs;
        AsyncOperationHandle stageTMOp;

        public AssetsManager() {
            entityPrefabs = new Dictionary<string, GameObject>();
            uiPrefabs = new Dictionary<string, GameObject>();

            roleTMs = new Dictionary<int, RoleTM>();
            propTMs = new Dictionary<int, PropTM>();
            stageTMs = new Dictionary<ulong, StageTM>();
        }

        public void Load() {
            {
                var op = Addressables.LoadAssetsAsync<GameObject>("Entity", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var prefab = list[i];
                    entityPrefabs.Add(prefab.name, prefab);
                }
                this.entityOp = op;
            }
            {
                var op = Addressables.LoadAssetsAsync<GameObject>("UI", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var prefab = list[i];
                    uiPrefabs.Add(prefab.name, prefab);
                }
                this.uiOp = op;
            }

            {
                var op = Addressables.LoadAssetsAsync<RoleTM>("TM_Role", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var tm = list[i];
                    roleTMs.Add(tm.typeID, tm);
                }
                this.roleTMOp = op;
            }

            {
                var op = Addressables.LoadAssetsAsync<PropTM>("TM_Prop", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var tm = list[i];
                    propTMs.Add(tm.typeID, tm);
                }
                this.propTMOp = op;
            }

            {
                var op = Addressables.LoadAssetsAsync<StageTM>("TM_Stage", null);
                var list = op.WaitForCompletion();
                for (int i = 0; i < list.Count; i++) {
                    var tm = list[i];
                    ulong key = GetStageKey(tm.chapter, tm.level);
                    stageTMs.Add(key, tm);
                }
                this.stageTMOp = op;
            }
        }

        public void Unload() {
            if (entityOp.IsValid()) {
                Addressables.Release(entityOp);
            }
            if (uiOp.IsValid()) {
                Addressables.Release(uiOp);
            }
            if (roleTMOp.IsValid()) {
                Addressables.Release(roleTMOp);
            }
            if (propTMOp.IsValid()) {
                Addressables.Release(propTMOp);
            }
            if (stageTMOp.IsValid()) {
                Addressables.Release(stageTMOp);
            }
        }

        #region UI
        public bool UI_TryGet(string name, out GameObject prefab) {
            return uiPrefabs.TryGetValue(name, out prefab);
        }
        #endregion UI

        #region Entity
        public bool Entity_TryGetRole(out GameObject prefab) {
            return TryGetEntityPrefab("RoleEntity", out prefab);
        }

        public bool Entity_TryGetProp(out GameObject prefab) {
            return TryGetEntityPrefab("PropEntity", out prefab);
        }

        public bool Entity_TryGetStage(out GameObject prefab) {
            return TryGetEntityPrefab("StageEntity", out prefab);
        }

        bool TryGetEntityPrefab(string name, out GameObject prefab) {
            return entityPrefabs.TryGetValue(name, out prefab);
        }
        #endregion Entity

        #region TM
        public bool Role_TryGet(int typeID, out RoleTM tm) {
            return roleTMs.TryGetValue(typeID, out tm);
        }

        public bool Prop_TryGet(int typeID, out PropTM tm) {
            return propTMs.TryGetValue(typeID, out tm);
        }

        public bool Stage_TryGet(int chapter, int level, out StageTM tm) {
            ulong key = GetStageKey(chapter, level);
            return stageTMs.TryGetValue(key, out tm);
        }

        ulong GetStageKey(int chapter, int level) {
            return ((ulong)chapter << 32) | (uint)level;
        }
        #endregion TM

    }

}