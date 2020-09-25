using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class PrefabCollection : MonoBehaviour {

        static PrefabCollection m_instance;
        public static PrefabCollection Instance => m_instance;

        public RainSpike rainPrefab;

        void Awake() {

            if (m_instance == null) {
                m_instance = this;
            }
            
        }
    }
}