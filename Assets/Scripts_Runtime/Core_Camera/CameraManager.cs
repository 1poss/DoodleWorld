using UnityEngine;
using GameFunctions;

namespace DoodleWorldNS {

    public class CameraManager {

        Camera mainCam;

        public CameraManager() { }

        public void Inject(Camera mainCam) {
            this.mainCam = mainCam;
        }

        public void Follow(Vector2 targetPos, Vector2 confineMin, Vector2 confineMax) {
            float z = mainCam.transform.position.z;
            Vector3 pos = new Vector3(targetPos.x, targetPos.y, z);
            pos = GFCamera2D.CalcConfinePos(pos, confineMin, confineMax, mainCam.orthographicSize, mainCam.aspect);
            mainCam.transform.position = new Vector3(pos.x, pos.y, z);
        }

    }

}