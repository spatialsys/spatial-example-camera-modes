using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(SpatialTriggerEvent))]
    public class SideViewScript : MonoBehaviour
    {
        [SerializeField] SpatialVirtualCamera vcam;
        private Vector3 playerPos;
        private SpatialTriggerEvent spatialTrigger;
        void Start()
        {
            spatialTrigger = GetComponent<SpatialTriggerEvent>();
            spatialTrigger.onEnterEvent += EnableCam;
            spatialTrigger.onExitEvent += DisableCam;
        }
        void OnDestroy()
        {
            spatialTrigger.onEnterEvent -= EnableCam;
            spatialTrigger.onExitEvent -= DisableCam;
        }
        void EnableCam()
        {
            vcam.enabled = true;
        }
        void DisableCam()
        {
            vcam.enabled = false;
        }
        public void Update()
        {
            playerPos = SpatialBridge.actorService.localActor.avatar.position;
            playerPos.z = 50;
            vcam.transform.position = playerPos;
        }
    }
}