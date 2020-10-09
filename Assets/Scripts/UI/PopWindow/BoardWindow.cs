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

        public BoardLine meLine;
        List<BoardLine> worldLineList;

        void Start() {

            worldLineList = new List<BoardLine>();

            bestTimeBtn.gameObject.GetComponent<Image>().color = Color.white;
            deadTimesBtn.gameObject.GetComponent<Image>().color = Color.gray;

            bestTimeBtn.onClick.AddListener(async () => {
                await ReqBest();
            });
            deadTimesBtn.onClick.AddListener(async () => {
                await ReqDead();
            });

        }

        public async Task ReqBest() {

            deadTimesBtn.gameObject.GetComponent<Image>().color = Color.gray;
            bestTimeBtn.gameObject.GetComponent<Image>().color = Color.white;
            await web.GetBestBoard();

        }

        public async Task ReqDead() {

            deadTimesBtn.gameObject.GetComponent<Image>().color = Color.white;
            bestTimeBtn.gameObject.GetComponent<Image>().color = Color.gray;
            await web.GetDeadBoard();

        }

        public void SwitchToBest(BoardInfo boardInfo) {

            CleanList();

            meLine.LoadBest(boardInfo.me, false);

            if (boardInfo.bestList != null) {

                for (int i = 0; i < boardInfo.bestList.Count; i += 1) {

                    UserRank rank = boardInfo.bestList[i];

                    BoardLine line = Instantiate(PrefabCollection.Instance.boardLinePrefab, viewPortBD.transform);

                    line.LoadBest(rank, false);

                    worldLineList.Add(line);

                }

            }

        }

        public void SwitchToDead(BoardInfo boardInfo) {

            CleanList();

            meLine.LoadBest(boardInfo.me, true);

            if (boardInfo.bestList != null) {

                for (int i = 0; i < boardInfo.bestList.Count; i += 1) {

                    UserRank rank = boardInfo.bestList[i];

                    BoardLine line = Instantiate(PrefabCollection.Instance.boardLinePrefab, viewPortBD.transform);

                    line.LoadBest(rank, true);

                    worldLineList.Add(line);

                }

            }

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