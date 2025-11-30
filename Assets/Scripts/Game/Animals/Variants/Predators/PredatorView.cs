using System;
using System.Threading;
using CoreLogic.Utility;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Animals.Variants.Predators
{
    public class PredatorView : MonoBehaviour, IDisposable
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private float secondsToShow;
     
        private Camera _camera;
        private CancellationTokenSource _showTcs;

        private void Awake()
        {
            _camera = Camera.main;
            canvas.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (_camera == null || canvas.gameObject.activeSelf == false) return;
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            var camTransform = _camera.transform;
            canvas.transform.LookAt(
                canvas.transform.position + camTransform.rotation * Vector3.forward,
                camTransform.rotation * Vector3.up
            );
        }

        public void ShowForSecondsAsync()
        {
            TokenHelper.Dispose(_showTcs);
            
            LookAtCamera();
            canvas.gameObject.SetActive(true);

            _showTcs = new CancellationTokenSource();
            HideAfterDelayAsync(secondsToShow, _showTcs.Token).Forget();
        }

        private async UniTask HideAfterDelayAsync(
            float seconds,
            CancellationToken tcs)
        {
            try
            {
                await UniTask.Delay(
                    TimeSpan.FromSeconds(seconds),
                    cancellationToken: tcs
                );
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                canvas.gameObject.SetActive(false);
                TokenHelper.Dispose(_showTcs);
            }
        }

        public void Dispose()
        {
            TokenHelper.Dispose(_showTcs);
        }
    }
}