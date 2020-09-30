using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IWebManager {

        void Inject(IUIManager ui, IWorldManager world);
        void GetBestBoard(string uid);
        Task PostRegister(string username);
        Task PostLogin(string uid);

    }

}