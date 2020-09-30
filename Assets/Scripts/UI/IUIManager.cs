using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IUIManager {

        void Inject(IWorldManager world, IWebManager web);
        void EnterRegister();
        void RegisterFailed(string msg);
        void LoginFailed(string msg);
        void EnterTitle(string username);
        void EnterGame();
        
    }
}