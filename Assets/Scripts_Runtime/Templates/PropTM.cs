using System;
using UnityEngine;

namespace DoodleWorldNS {

    [CreateAssetMenu(fileName = "Prop_TM_", menuName = "Templates/PropTM")]
    public class PropTM : ScriptableObject {

        public int typeID;

        public GameObject modPrefab;

    }

}