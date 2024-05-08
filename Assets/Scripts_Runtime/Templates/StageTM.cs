using System;
using UnityEngine;

namespace DoodleWorldNS {

    [CreateAssetMenu(fileName = "Stage_TM_", menuName = "Templates/StageTM")]
    public class StageTM : ScriptableObject {

        public int chapter;
        public int level;
        public Vector2 size;

        // Roles
        public StageRoleSpawnerTM[] roleSpawners;

        // Props
        public StagePropSpawnerTM[] propSpawners;

    }

}