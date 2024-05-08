using System;
using UnityEngine;

namespace DoodleWorldNS {

    [CreateAssetMenu(fileName = "Role_TM_", menuName = "Templates/RoleTM")]
    public class RoleTM : ScriptableObject {

        public int typeID;

        public float moveAccelerateSpeed;
        public float moveSpeedMax;
        public float fallingSpeed;
        public float fallingSpeedMax;

        public Sprite bodySpr;

    }

}