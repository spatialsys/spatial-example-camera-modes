using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(SpatialTriggerEvent))]
    public class TopDownScript : MonoBehaviour
    {
        [SerializeField] private GameObject vcam;
        private SpatialTriggerEvent spatialTrigger;

        void Start()
        {
            spatialTrigger = GetComponent<SpatialTriggerEvent>();
            spatialTrigger.onEnterEvent += ActivateCamera;
            spatialTrigger.onExitEvent += DeactivateCamera;
        }
        void OnDestroy()
        {
            spatialTrigger.onEnterEvent -= ActivateCamera;
            spatialTrigger.onExitEvent -= DeactivateCamera;
        }
        void ActivateCamera()
        {
            vcam.SetActive(true);
        }
        void DeactivateCamera()
        {
            vcam.SetActive(false);
        }
    }
}
