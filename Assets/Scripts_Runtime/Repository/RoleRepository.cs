using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out RoleEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public void Foreach(Action<RoleEntity> action) {
            foreach (var entity in all.Values) {
                action.Invoke(entity);
            }
        }

    }

}