using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public event Action<AnimalBase, Collision> CollisionEntered;
        
        [SerializeField] private AnimalView view;
        [SerializeField] private float moveSpeed = 2f;
        
        private Vector2 _direction;
        private CancellationTokenSource _moveCts;
        private Vector3 _lastDir;

        public void Initialize()
        {
            
        }
        
        #region === Unity Events ===

        private void OnEnable()
        {
            StartMoveOnField();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Collision Enter, {collision.transform.name}");
            CollisionEntered?.Invoke(this, collision);
        }

        private void OnDisable()
        {
            StopMoveOnField();
        }

        #endregion === Unity Events ===

        public float GetObjectHeight()
        {
            return view.GetObjectHeight();
        }
        
        private void StartMoveOnField()
        {
            CheckDirection();
            DisposeMoveToken();
            _moveCts = new CancellationTokenSource();

            MoveLoopAsync(_moveCts.Token).Forget();
        }
        
        private void StopMoveOnField()
        {
            DisposeMoveToken();
            _direction =  Vector2.zero;
        }

        private void RandomizeDirection()
        {
            _direction = Random.insideUnitCircle.normalized;
        }

        private void CheckDirection()
        {
            if (_direction == Vector2.zero) RandomizeDirection();
        }

        private void DisposeMoveToken()
        {
            if (_moveCts == null) return;
            
            _moveCts.Cancel();
            _moveCts.Dispose();
            _moveCts = null;
        }
        
        private async UniTaskVoid MoveLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var dir3 = new Vector3(_direction.x, 0f, _direction.y);
                if (dir3 != Vector3.zero && dir3 != _lastDir)
                {
                    transform.forward = dir3;
                    _lastDir = dir3;
                }
                view.ChangeVelocity(dir3 * moveSpeed);
                
                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
            }
        }
    }
}