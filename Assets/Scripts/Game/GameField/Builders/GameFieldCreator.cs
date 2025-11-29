using System;
using Game.GameField.Builders;
using Game.GameField.Builders.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.GameField
{
    public sealed class GameFieldCreator
    { 
        private GameFieldScaleCalculator _gameFieldScaler;
        private BuildersData _buildersData;
        
        public GameFieldCreator(BuildersData buildersData)
        {
            _buildersData =  buildersData;
            _gameFieldScaler = new GameFieldScaleCalculator(_buildersData);
        }
        
        public GameFieldView CreateFullScreenFieldView()
        {
            var camera = _buildersData.TargetCamera;
            if (camera == null) throw new ArgumentException("Target camera is null");

            var plane = Object.Instantiate(_buildersData.GameFieldPrefab, _buildersData.GameFieldParent);
            plane.transform.rotation = Quaternion.identity;

            plane.transform.localScale = _gameFieldScaler.CalculateScale();
            
            var distance = Mathf.Abs(camera.transform.position.y);
            
            var screenCenter = camera.ScreenToWorldPoint(
                new Vector3(Screen.width / 2f, Screen.height / 2f, distance)
            );

            plane.transform.position = screenCenter;
            
            return plane;
        }
    }
}