using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(SpatialTriggerEvent))]
    public class OverShoulderScript : MonoBehaviour
    {
        [SerializeField] private Vector3 cameraOffset;
        private SpatialTriggerEvent spatialTrigger;

        void Start()
        {
            spatialTrigger = GetComponent<SpatialTriggerEvent>();
            spatialTrigger.onEnterEvent += ActivateThirdPerson;
            spatialTrigger.onExitEvent += DeactivateThirdPerson;
        }
        void OnDestroy()
        {
            spatialTrigger.onEnterEvent -= ActivateThirdPerson;
            spatialTrigger.onExitEvent -= DeactivateThirdPerson;
        }
        void ActivateThirdPerson()
        {
            SpatialBridge.cameraService.zoomDistance = 1;
            SpatialBridge.cameraService.minZoomDistance = 1;
            SpatialBridge.cameraService.maxZoomDistance = 3;
            SpatialBridge.cameraService.thirdPersonFov = 60;
            SpatialBridge.cameraService.thirdPersonOffset = cameraOffset;
        }
        void DeactivateThirdPerson()
        {
            SpatialBridge.cameraService.zoomDistance = 6;
            SpatialBridge.cameraService.minZoomDistance = 0;
            SpatialBridge.cameraService.maxZoomDistance = 10;
            SpatialBridge.cameraService.thirdPersonFov = 70;
            SpatialBridge.cameraService.thirdPersonOffset = Vector3.zero;
        }
    }
}
