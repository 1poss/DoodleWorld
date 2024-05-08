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
                    Coll_Enter_Role_I_Prop(ctx, me, prop, other);
                }
            };

            entity.OnTriggerEnterHandle = (me, other) => {
                var otherGo = other.gameObject;
                if (otherGo.layer == LayerConst.PROP) {
                    var prop = otherGo.GetComponentInParent<PropEntity>();
                    Trig_Enter_Role_I_Prop(ctx, me, prop);
                }
            };

            entity.SR_Set(tm.bodySpr);

            entity.fsmCom.Normal_Enter();

            ctx.roleRepository.Add(entity);

            return entity;

        }

        // ==== Collision ====
        static void Coll_Enter_Role_I_Prop(GameContext ctx, RoleEntity role, PropEntity prop, Collision2D collision) {
            Role_I_Prop_Bounce(role, prop, collision);
        }

        static void Role_I_Prop_Bounce(RoleEntity role, PropEntity prop, Collision2D collision) {
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
                    bounceDir = normal;
                }
                bounceDir.Normalize();
                role.Bounce(bounceDir * prop.bounceForce);
            }
        }

        // ==== Trigger ====
        static void Trig_Enter_Role_I_Prop(GameContext ctx, RoleEntity role, PropEntity prop) {
            Role_I_Prop_Key(ctx, role, prop);
            Role_I_Prop_Door(ctx, role, prop);
        }

        static void Role_I_Prop_Key(GameContext ctx, RoleEntity role, PropEntity prop) {
            if (!prop.isKey) {
                return;
            }
            // 找到门, 打开
            var door = ctx.propRepository.GetDoor();
            door.Door_Open();

            PropDomain.Unspawn(ctx, prop);
        }

        static void Role_I_Prop_Door(GameContext ctx, RoleEntity role, PropEntity prop) {
            if (role.allyStatus == AllyStatus.Player && prop.isDoor && prop.isDoorOpen) {
                // 进入下一关
                GameDomain.TryEnterNextStage(ctx);
            }
        }

    }

}