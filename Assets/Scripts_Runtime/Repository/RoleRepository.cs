using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS {

    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        RoleEntity[] temp;

        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
            temp = new RoleEntity[100];
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

        public int TakeAll(out RoleEntity[] entities) {
            int count = all.Count;
            if (count == 0) {
                entities = null;
                return 0;
            }
            if (count > temp.Length) {
                temp = new RoleEntity[count];
            }

            all.Values.CopyTo(temp, 0);
            entities = temp;
            return count;
        }

    }

}