using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS {

    public class PropRepository {

        Dictionary<int, PropEntity> all;

        PropEntity[] temp;

        public PropRepository() {
            all = new Dictionary<int, PropEntity>();
            temp = new PropEntity[1000];
        }

        public void Add(PropEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out PropEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public void Foreach(Action<PropEntity> action) {
            foreach (var entity in all.Values) {
                action.Invoke(entity);
            }
        }

        public int TakeAll(out PropEntity[] entities) {
            if (all.Count > temp.Length) {
                temp = new PropEntity[all.Count];
            }
            all.Values.CopyTo(temp, 0);
            entities = temp;
            return all.Count;
        }

    }

}