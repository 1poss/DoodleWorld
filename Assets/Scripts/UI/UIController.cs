using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public static class UIController {

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