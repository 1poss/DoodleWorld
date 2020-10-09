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
        public Button closeBtn;

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

            closeBtn.onClick.AddListener(this.Hide);

            this.Hide();

        }

        public async Task ReqBest() {

            await web.GetBestBoard();

        }

        public async Task ReqDead() {
            
            await web.GetDeadBoard();

        }

        public void SwitchToBest(BoardInfo boardInfo) {

            this.Show();

            deadTimesBtn.gameObject.GetComponent<Image>().color = Color.gray;
            bestTimeBtn.gameObject.GetComponent<Image>().color = Color.white;

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

            this.Show();

            deadTimesBtn.gameObject.GetComponent<Image>().color = Color.white;
            bestTimeBtn.gameObject.GetComponent<Image>().color = Color.gray;

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