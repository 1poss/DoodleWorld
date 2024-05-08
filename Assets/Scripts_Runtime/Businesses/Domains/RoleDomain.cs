using System;
using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, AllyStatus allyStatus, Vector2 pos, float rot) {

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
            entity.allyStatus = allyStatus;

            entity.moveAccelerateSpeed = tm.moveAccelerateSpeed;
            entity.moveSpeedMax = tm.moveSpeedMax;
            entity.fallingSpeed = tm.fallingSpeed;
            entity.fallingSpeedMax = tm.fallingSpeedMax;

            entity.OnCollisionEnterHandle = (me, other) => {
                var otherGo = other.gameObject;
                if (otherGo.layer == LayerConst.PROP) {
                    var prop = otherGo.GetComponentInParent<PropEntity>();
                    Coll_Enter_Role_Prop(ctx, me, prop, other);
                }
            };

            entity.SR_Set(tm.bodySpr);

            entity.fsmCom.Normal_Enter();

            ctx.roleRepository.Add(entity);

            return entity;

        }

        static void Coll_Enter_Role_Prop(GameContext ctx, RoleEntity role, PropEntity prop, Collision2D collision) {
            if (prop.isBounce) {
                if (collision.contacts.Length == 0) {
                    return;
                }
                Vector2 normal = collision.contacts[0].normal;
                if (normal.x == 1 || normal.x == -1) {
                    return;
                }
                if (normal.y <= 0) {
                    return;
                }
                Vector2 bounceDir = prop.bounceDir;
                if (bounceDir == Vector2.zero) {
                    bounceDir = role.transform.position - prop.transform.position;
                }
                bounceDir.Normalize();
                role.Bounce(bounceDir * prop.bounceForce);
            }
        }

    }

}