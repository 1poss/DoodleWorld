using System;
using UnityEngine;

namespace DoodleWorldNS {

    public static class AudioController {

        public static event Action<object, SoundType> PlaySoundEvent;
        public static void OnPlaySoundEvent(object sender, SoundType soundType) {
            PlaySoundEvent?.Invoke(sender, soundType);
        }

        public static event Action<object, bool> PlayBGMEvent;
        public static void OnPlayBGMEvent(object sender, bool isPlay) {
            PlayBGMEvent?.Invoke(sender, isPlay);
        }
    }
}