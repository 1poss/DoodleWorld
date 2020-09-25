using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    [ExecuteAlways]
    public class SpikeBridge : MonoBehaviour {

        Vector2 defaultPos;
        List<GameObject> centerList;
        GameObject left;
        public GameObject leftPrefab;
        GameObject right;
        public GameObject rightPrefab;
        public GameObject centerPrefab;

        [Min(2)]
        public int bridgeLength;
        public bool isHorizontal;

        [ContextMenu("ReStart")]
        void Start() {

            defaultPos = transform.position;
            transform.rotation = new Quaternion();

            // 清
            int childCount = transform.childCount;
            for (int i = childCount - 1; i >= 0; i -= 1) {
                Transform t = transform.GetChild(i);
                DestroyImmediate(t.gameObject);
            }
            // GameObject[] goes = gameObject.transform.GetComponentsInChildren<GameObject>();
            // foreach (GameObject go in goes) {
            //     DestroyImmediate(go.gameObject);
            // }

            // 左
            if (left == null) {
                left = Instantiate(leftPrefab, transform);
                left.transform.position = defaultPos;
            }

            // 中
            if (bridgeLength >= 2) {

                for (int i = 0; i < bridgeLength - 2; i += 1) {

                    GameObject go = Instantiate(centerPrefab, transform);
                    go.transform.position = defaultPos + Vector2.right * (i + 1);

                }

            } else {

                DebugUtil.LogError("BridgeLength MustBe 2 Or Longer");

            }

            // 右
            if (right == null) {
                right = Instantiate(rightPrefab, transform);
                right.transform.position = defaultPos + Vector2.right * (bridgeLength - 1);
            }

            // 旋转
            if (!isHorizontal) {

                transform.Rotate(0, 0, 90);

            }

        }
        
        void ClearList() {
            
            if (centerList == null) {
                return;
            }

            for(int i = centerList.Count - 1; i >= 0; i -= 1) {
                GameObject go = centerList[i];
                DestroyImmediate(go.gameObject);
            }

            centerList.Clear();
        }

    }
}