using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleWorldNS {

    public class StageRepository {

        Dictionary<int, StageEntity> all;
        StageEntity current;

        public StageRepository() {
            all = new Dictionary<int, StageEntity>();
        }

        public void SetCurrent(StageEntity entity) {
            current = entity;
        }

        public StageEntity GetCurrent() {
            return current;
        }

        public void Add(StageEntity entity) {
            all.Add(entity.id, entity);
        }

        public void Remove(StageEntity entity) {
            all.Remove(entity.id);
        }

        public bool TryGet(int id, out StageEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Clear() {
            all.Clear();
        }

    }
}