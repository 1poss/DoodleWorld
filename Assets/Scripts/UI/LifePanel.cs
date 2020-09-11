using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class LifePanel : MonoBehaviour {

        public GameObject bd;
        public Image lifeImgPrefab;
        List<Image> lifeList;

        protected virtual void Awake() {

            lifeList = new List<Image>();

        }

        public virtual void LoadLife(object sender, Player player) {

            Clear();

            for (int i = 0; i < player.life; i += 1) {

                Image life = Instantiate(lifeImgPrefab, bd.transform);
                lifeList.Add(life);

            }

        }

        public virtual void ReduceLife(object sender, ReduceLifeEventArgs args) {

            Player player = args.player;
            int reduceNumber = args.reduceNumber;

            if (lifeList.Count < reduceNumber) {

                Clear();
                return;

            }

            for (int i = reduceNumber - 1; i >= 0; i -= 1) {

                Image life = lifeList[i];
                Destroy(life.gameObject);
                lifeList.RemoveAt(i);

            }

        }

        public virtual void AddLife(object sender, AddLifeEventArgs args) {

            Player player = args.player;
            int addNumber = args.addNumber;

            if (lifeList.Count >= player.lifeMax) {

                return;

            }

            if (lifeList.Count + addNumber >= player.lifeMax) {

                addNumber = player.lifeMax - lifeList.Count;

            }

            for (int i = 0; i < addNumber; i += 1) {

                Image life = Instantiate(lifeImgPrefab, bd.transform);
                lifeList.Add(life);

            }

        }

        void Clear() {

            if (lifeList != null) {

                for (int i = 0; i < lifeList.Count; i += 1) {

                    Image img = lifeList[i];

                    if (img != null) {

                        Destroy(img.gameObject);

                    }

                }

                lifeList.Clear();

            }

            
        }

    }
}