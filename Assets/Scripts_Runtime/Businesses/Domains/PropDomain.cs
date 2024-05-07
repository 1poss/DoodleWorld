using System;
using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class PropDomain {

        public static PropEntity Spawn(GameContext ctx, int typeID, Vector2 pos, float rot) {

            bool has = ctx.assets.Prop_TryGet(typeID, out var tm);
            if (!has) {
                Debug.LogError($"Prop not found: {typeID}");
                return null;
            }

            has = ctx.assets.Entity_TryGetProp(out var prefab);
            if (!has) {
                Debug.LogError($"Prop prefab not found");
                return null;
            }

            var go = GameObject.Instantiate(prefab, pos, Quaternion.Euler(0, 0, rot));
            var mod = GameObject.Instantiate(tm.modPrefab, go.transform).GetComponent<PropMod>();

            var entity = go.GetComponent<PropEntity>();
            entity.Ctor(mod);
            entity.id = ctx.idService.propIDRecord++;

            ctx.propRepository.Add(entity);

            return entity;

        }
    }
}