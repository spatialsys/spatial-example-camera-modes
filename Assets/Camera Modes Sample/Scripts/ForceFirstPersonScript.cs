using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(SpatialTriggerEvent))]
    public class ForceFirstPersonScript : MonoBehaviour
    {
        private SpatialTriggerEvent spatialTrigger;

        void Start()
        {
            spatialTrigger = GetComponent<SpatialTriggerEvent>();
            spatialTrigger.onEnterEvent += ActivateFirstPerson;
            spatialTrigger.onExitEvent += DectivateFirstPerson;
        }
        void OnDestroy()
        {
            spatialTrigger.onEnterEvent -= ActivateFirstPerson;
            spatialTrigger.onExitEvent -= DectivateFirstPerson;
        }
        public void ActivateFirstPerson()
        {
            SpatialBridge.cameraService.forceFirstPerson = true;
        }
        public void DectivateFirstPerson()
        {
            SpatialBridge.cameraService.forceFirstPerson = false;
        }
    }
}
