using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public static class UIController {

        // 标题相关
        public static event Action<object, EventArgs> StartGameEvent;
        public static void OnStartGameEvent(object sender, EventArgs args) {
            StartGameEvent?.Invoke(sender, args);
        }

        // 生命相关
        public static event Action<object, Player> LoadLifeEvent;
        public static void OnLoadLifeEvent(object sender, Player player) {
            LoadLifeEvent?.Invoke(sender, player);
        }

        public static event Action<object, ReduceLifeEventArgs> ReduceLifeEvent;
        public static void OnReduceLifeEvent(object sender, ReduceLifeEventArgs args) {
            ReduceLifeEvent?.Invoke(sender, args);
        }

        public static event Action<object, AddLifeEventArgs> AddLifeEvent;
        public static void OnAddLifeEvent(object sender, AddLifeEventArgs args) {
            AddLifeEvent?.Invoke(sender, args);
        }

        // 菜单相关
        public static event Action<object, EventArgs> PopupPauseEvent;
        public static void OnPopupPauseEvent(object sender, EventArgs args) {
            PopupPauseEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> PopupGameOverEvent;
        public static void OnPopupGameOverEvent(object sender, EventArgs args) {
            PopupGameOverEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> PopupFinishedGameEvent;
        public static void OnPopupFinishedGameEvent(object sender, EventArgs args) {
            PopupFinishedGameEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> ReturnGameEvent;
        public static void OnReturnGameEvent(object sender, EventArgs args) {
            ReturnGameEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> RetryEvent;
        public static void OnRetryEvent(object sender, EventArgs args) {
            RetryEvent?.Invoke(sender, args);
        }

        public static event Action<object, EventArgs> BackToTitleEvent;
        public static void OnBackToTitleEvent(object sender, EventArgs args) {
            BackToTitleEvent?.Invoke(sender, args);
        }

    }

    public class ReduceLifeEventArgs : EventArgs {

        public Player player;
        public int reduceNumber;

        public ReduceLifeEventArgs(Player player, int reduceNumber) {
            this.player = player;
            this.reduceNumber = reduceNumber;
        }

    }

    public class AddLifeEventArgs : EventArgs {

        public Player player;
        public int addNumber;

        public AddLifeEventArgs(Player player, int addNumber) {
            this.player = player;
            this.addNumber = addNumber;
        }
    }
}