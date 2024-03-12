using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using TMPro;

namespace CreatorToolkitCustomScripts
{
    [RequireComponent(typeof(SpatialInteractable))]
    public class BigBoomScript : MonoBehaviour
    {
        [SerializeField] private AudioSource countdownAudio;
        [SerializeField] private AudioSource explosionAudio;
        [SerializeField] private ParticleSystem explosionParticles;
        [SerializeField] private GameObject explodingBarrels;
        private SpatialInteractable interactable;
        void Start()
        {
            interactable = GetComponent<SpatialInteractable>();
            interactable.onInteractEvent += OnInteract;
        }
        void OnDestroy()
        {
            interactable.onInteractEvent -= OnInteract;
        }
        public void OnInteract()
        {
            StartCoroutine(ExplosionCoroutine());
        }
        private IEnumerator ExplosionCoroutine()
        {
            countdownAudio.Play();
            yield return new WaitForSeconds(countdownAudio.clip.length);
            explosionParticles.Play();
            explosionAudio.Play();
            explodingBarrels.SetActive(false);
            SpatialBridge.cameraService.shakeAmplitude = 1;
            SpatialBridge.cameraService.Wobble(1);
            SpatialBridge.cameraService.Wobble(new Vector3(5, 5, 5));
            SpatialBridge.cameraService.Kick(new Vector2(20, 20));
            SpatialBridge.cameraService.kickDecay = 200;
            yield return new WaitForSeconds(1.8f);
            explosionParticles.Stop();
            yield return new WaitForSeconds(2);
            explodingBarrels.SetActive(true);
        }
    }
}
