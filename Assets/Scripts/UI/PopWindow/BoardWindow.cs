using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class BoardWindow : MonoBehaviour {

        public UIManager ui;
        public WebManager web;

        public GameObject viewPortBD;

        public Button bestTimeBtn;
        public Button deadTimesBtn;

        BoardLine currentLine;
        List<BoardLine> worldLineList;

        void Start() {

            worldLineList = new List<BoardLine>();

            bestTimeBtn.onClick.AddListener(async () => {
                await web.GetBestBoard();
            });
            deadTimesBtn.onClick.AddListener(async () => {
                await web.GetDeadBoard();
            });

        }

        public void SwitchToBest(BoardInfo boardInfo) {

            CleanList();

        }

        public void SwitchToDead(BoardInfo boardInfo) {

            CleanList();

        }

        void CleanList() {

            if (worldLineList == null) {
                return;
            }

            for (int i = worldLineList.Count - 1; i >= 0; i -= 1) {

                BoardLine b = worldLineList[i];
                Destroy(b.gameObject);

            }

            worldLineList.Clear();

        }

    }

}