using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class App : MonoBehaviour {

        void Awake() {

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

        }

    }

}