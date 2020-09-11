using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public static class LevelController {

        public static event Action<object, Player> ReloadLevelEvent;
        public static void OnReloadLevelEvent(object sender, Player player) {
            ReloadLevelEvent?.Invoke(sender, player);
        }

    }
}