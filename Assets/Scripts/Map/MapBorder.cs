using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class MapBorder : MonoBehaviour {

        public Tilemap borderTilemap;
        public Vector2 bounds;

        void Awake() {

            borderTilemap = GetComponent<Tilemap>();

        }

        protected virtual void OnCollisionEnter2D(Collision2D other) {

            if (other.gameObject.tag == TagCollection.PLAYER) {

                Player p = other.gameObject.GetComponent<Player>();
                p.Dead(this, EventArgs.Empty);

            } else if (other.gameObject.tag == TagCollection.BULLET) {

                BossBullet b = other.gameObject.GetComponent<BossBullet>();
                Destroy(b.gameObject);

            }

        }
    }
}