using System;
using System.Threading;
using CoreLogic.Utility;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Game.Animals.Behaviour.Movers
{
    public class LinearMover : IMover, IDisposable
    {
        private readonly AnimalView _view;
        private readonly Transform _transform;
        private readonly float _moveSpeed;

        private Vector2 _direction;
        private Vector3 _lastDir;
        private CancellationTokenSource _moveCts;

        public LinearMover(AnimalView view, Transform transform, float moveSpeed)
        {
            _view = view;
            _transform = transform;
            _moveSpeed = moveSpeed;
        }

        private void RandomizeDirection()
        {
            if (_direction != Vector2.zero) return;
            _direction = Random.insideUnitCircle.normalized;
        }

        public void StartMove()
        {
            RandomizeDirection();
            TokenHelper.Dispose(_moveCts);

            _moveCts = new CancellationTokenSource();
            MoveLoopAsync(_moveCts.Token).Forget();
        }

        public void StopMove()
        {
            TokenHelper.Dispose(_moveCts);
            _direction = Vector2.zero;
            _view.ChangeVelocity(Vector3.zero);
        }

        public void OnBlockedByObstacle(Vector2 obstacleNormal)
        {
            if (_direction == Vector2.zero)
            {
                RandomizeDirection();
                return;
            }

            if (obstacleNormal == Vector2.zero)
                return;

            var dir = _direction.normalized;
            var n   = obstacleNormal.normalized;

            var cw  = NormalsHelper.GetPerpendicular(dir, clockwise: true);
            var ccw = NormalsHelper.GetPerpendicular(dir, clockwise: false);

            _direction = NormalsHelper.ChooseSlideDirection(dir, n, cw, ccw);
        }

        private async UniTaskVoid MoveLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var dir3 = new Vector3(_direction.x, 0f, _direction.y);

                if (dir3 != Vector3.zero && dir3 != _lastDir)
                {
                    _transform.forward = dir3;
                    _lastDir = dir3;
                }

                _view.ChangeVelocity(dir3 * _moveSpeed);

                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
            }
        }

        public void Dispose()
        {
            TokenHelper.Dispose(_moveCts);
        }
    }
}