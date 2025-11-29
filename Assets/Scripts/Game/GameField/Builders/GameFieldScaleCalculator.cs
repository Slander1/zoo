using System;
using Game.GameField.Builders.Data;
using UnityEngine;

namespace Game.GameField.Builders
{
    public sealed class GameFieldScaleCalculator
    {
        private readonly BuildersData _buildersData;
        public GameFieldScaleCalculator(BuildersData buildersData)
        {
            _buildersData = buildersData;
        }

        public Vector3 CalculateScale()
        {
            var camera = _buildersData.TargetCamera;

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));
            if (Mathf.Approximately(_buildersData.BaseMeshSize, 0f))
                throw new ArgumentException("Base mesh size cannot be zero.");
            
            var distance = Mathf.Abs(camera.transform.position.y);
            var bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, distance));
            var topRight   = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));

            var worldWidth  = Mathf.Abs(topRight.x - bottomLeft.x);
            var worldHeight = Mathf.Abs(topRight.z - bottomLeft.z);
            
            var reduceX = worldWidth  * (_buildersData.PaddingPercentX / 100f);
            var reduceZ = worldHeight * (_buildersData.PaddingPercentY / 100f);
            
            var finalWidth  = worldWidth  - reduceX;
            var finalHeight = worldHeight - reduceZ;
            
            return new Vector3(
                finalWidth  / _buildersData.BaseMeshSize,
                1,
                finalHeight / _buildersData.BaseMeshSize
            );;
        }
    }
}