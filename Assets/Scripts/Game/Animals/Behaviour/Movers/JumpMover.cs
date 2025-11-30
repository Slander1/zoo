using System;
using System.Threading;
using CoreLogic.Utility;
using Cysharp.Threading.Tasks;
using Game.Animals.Behaviour.Movers.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Animals.Behaviour.Movers
{
    public class JumpMover : IGenericMover<JumpMoverData>, IDisposable
    {
        private JumpMoverData _data;
        
        private Vector2 _direction;
        private Vector3 _lastDir;
        private CancellationTokenSource _moveCts;

        // множитель скорости только на ближайший прыжок
        private float _repulseSpeedMultiplier = 1f;

        public void Initialize(JumpMoverData data)
        {
            _data = data;
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
            _data.View.ChangeVelocity(Vector3.zero);
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
                _data.View.ChangeVelocity(Vector3.zero);

                try
                {
                    await UniTask.Delay(
                        TimeSpan.FromSeconds(_data.JumpIntervalSeconds),
                        cancellationToken: token
                    );
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                if (token.IsCancellationRequested)
                    break;

                var elapsed = 0f;
                
                var basePos = _data.Transform.position;
                var baseY   = basePos.y;

                while (elapsed < _data.JumpDurationSeconds && !token.IsCancellationRequested)
                {
                    var dir3 = new Vector3(_direction.x, 0f, _direction.y);

                    if (dir3 != Vector3.zero && dir3 != _lastDir)
                    {
                        _data.Transform.forward = dir3;
                        _lastDir = dir3;
                    }

                    var speed = _data.MoveSpeed * _repulseSpeedMultiplier;
                    _data.View.ChangeVelocity(dir3 * speed);

                    var t = elapsed / _data.JumpDurationSeconds;
                    var height = Mathf.Sin(t * Mathf.PI) * _data.JumpHeight;

                    var pos = _data.Transform.position;
                    pos.y   = baseY + height;
                    _data.Transform.position = pos;

                    elapsed += Time.fixedDeltaTime;
                    await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
                }

                var resetPos = _data.Transform.position;
                resetPos.y = baseY;
                _data.Transform.position = resetPos;

                _repulseSpeedMultiplier = 1f;
                _data.View.ChangeVelocity(Vector3.zero);
            }
        }

        public void Dispose()
        {
            TokenHelper.Dispose(_moveCts);
        }
        
        public void Repulsed(Vector3 direction, float strength)
        {
            direction.y = 0f;
            if (direction == Vector3.zero)
                return;

            direction.Normalize();

            _direction = new Vector2(direction.x, direction.z);

            _repulseSpeedMultiplier = Mathf.Max(1f, strength);
        }
    }
}