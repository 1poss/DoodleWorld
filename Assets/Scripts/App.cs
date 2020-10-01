using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class App : MonoBehaviour {

        static App m_instance;
        public static App Instance => m_instance;
 
        // ---- Managers ----
        public WebManager web;
        public UIManager ui;
        public WorldManager world;
        public DataManager data;

        // ---- DEBUG ----
        public GameObject debugMapEditor;

        void Awake() {

            if (m_instance == null) {
                m_instance = this;
            }

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

            Physics2D.IgnoreLayerCollision(LayerCollection.BULLET_LAYER, LayerCollection.SPIKE_LAYER);
            Physics2D.IgnoreLayerCollision(LayerCollection.RAIN_LAYER, LayerCollection.SPIKE_LAYER);
            Physics2D.IgnoreLayerCollision(LayerCollection.RAIN_LAYER, LayerCollection.RAIN_LAYER);

        }

        void Start() {

            web.Inject(ui, world, data);
            ui.Inject(world, web);
            world.Inject(ui, web);
            data.Inject();

            // 一切的开始在于 UI
            data.Init();
            ui.Init();

            // 删除 Debug 用的组件
            if (debugMapEditor != null && debugMapEditor.activeSelf) {

                Destroy(debugMapEditor);

            }

        }

    }

}