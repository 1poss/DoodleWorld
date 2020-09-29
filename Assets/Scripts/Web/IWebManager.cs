using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    interface IWebManager {

        void GetBestBoard(string uid);
        Task Register(string username);
        Task Login(string uid);

    }

}