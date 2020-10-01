using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public enum SoundType {

        TreeBounce,
        PlatformBounce,
        EnterDoor,
        Gather,
        Dead,

    }

    public class AudioManager : MonoBehaviour, IAudioManager {

        public AudioSource bgmPlayer;
        public AudioSource soundPlayer;

        public AudioClip treeBounce;
        public AudioClip platformBounce;
        public AudioClip enterDoor;
        public AudioClip gather;
        public AudioClip dead;

        public void PlaySound(SoundType soundType) {

            if (soundPlayer.clip == enterDoor && soundPlayer.isPlaying && soundType == SoundType.PlatformBounce) {
                return;
            }

            if (soundPlayer.clip == dead && soundPlayer.isPlaying && soundType == SoundType.PlatformBounce) {
                return;
            }

            switch(soundType) {
                case SoundType.TreeBounce:
                    soundPlayer.clip = treeBounce;
                    break;
                case SoundType.PlatformBounce:
                    soundPlayer.clip = platformBounce;
                    break;
                case SoundType.EnterDoor:
                    soundPlayer.clip = enterDoor;
                    break;
                case SoundType.Gather:
                    soundPlayer.clip = gather;
                    break;
                case SoundType.Dead:
                    soundPlayer.clip = dead;
                    break;
            }

            soundPlayer.Play();

        }

        public void PlayBGM(bool isPlay) {

            if (isPlay) {

                bgmPlayer.Play();
                
            } else {

                bgmPlayer.Stop();

            }

        }
    }
}