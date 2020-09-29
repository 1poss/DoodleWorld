using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    interface IUIManager {

        void EnterRegister();
        void RegisterFailed(string msg);
        void LoginFailed(string msg);
        void EnterTitle(string username);
        void EnterGame();
        
    }
}