using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IUIManager {

        void EnterRegister();
        void RegisterFailed(string msg);
        void LoginFailed(string msg);
        void EnterTitle(string username);
        void EnterGame(bool isNewGame);

        void LoadLife(Player player);
        void AddLife(Player player, int number = 1);
        void ReduceLife(Player player, int number = 1);

        void PauseGame();
        void RestorePauseGame();
        void RetryLevel();
        void GameOver();
        void FinishGame();

        void ShowAd();
        void AdFinished();
        void AdSkiped();
        
    }

}