using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IAudioManager {

        void PlaySound(SoundType sound);
        void PlayBGM(bool isPlay);

    }

}