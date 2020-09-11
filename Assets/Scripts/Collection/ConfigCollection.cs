using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public static class ConfigCollection {

        public static Vector3 cameraOffset;

        static ConfigCollection() {

            cameraOffset = new Vector3(15f, 8.5f, -10f);
            
        }
    }
}