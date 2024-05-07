using System;
using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos, float rot) {

            bool has = ctx.assets.Role_TryGet(typeID, out var tm);
            if (!has) {
                Debug.LogError($"Role not found: {typeID}");
                return null;
            }

            has = ctx.assets.Entity_TryGetRole(out var prefab);
            if (!has) {
                Debug.LogError($"Role prefab not found");
                return null;
            }

            var go = GameObject.Instantiate(prefab, pos, Quaternion.Euler(0, 0, rot));
            var entity = go.GetComponent<RoleEntity>();
            entity.Ctor();
            entity.id = ctx.idService.roleIDRecord++;

            entity.SR_Set(tm.bodySpr);

            ctx.roleRepository.Add(entity);

            return entity;

        }

    }

}