using System;
using UnityEngine;

namespace DoodleWorldNS {

    [CreateAssetMenu(fileName = "Prop_TM_", menuName = "Templates/PropTM")]
    public class PropTM : ScriptableObject {

        public int typeID;
        public string propName;

        public bool isBounce;
        public Vector2 bounceDir; // if dir is zero, then target - self
        public float bounceForce;

        public GameObject modPrefab;

    }

}