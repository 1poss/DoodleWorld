using System;
using UnityEngine;

namespace DoodleWorldNS.Domains {

    public static class StageDomain {

        public static StageEntity Spawn(GameContext ctx, int chapter, int level) {
            bool has = ctx.assets.Entity_TryGetStage(out var prefab);
            if (!has) {
                Debug.LogError("Stage prefab not found");
                return null;
            }

            has = ctx.assets.Stage_TryGet(chapter, level, out var stageTM);
            if (!has) {
                Debug.LogError($"Stage not found: {chapter}-{level}");
                return null;
            }

            var go = GameObject.Instantiate(prefab);
            var entity = go.GetComponent<StageEntity>();
            entity.Ctor();
            entity.id = ctx.idService.stageIDRecord++;
            entity.chapter = chapter;
            entity.level = level;
            entity.size = stageTM.size;

            ctx.stageRepository.Add(entity);
            return entity;
        }
    }
}