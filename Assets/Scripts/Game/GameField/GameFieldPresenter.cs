using System;
using Game.GameField.Builders.Data;
using Game.GameField.Builders.Walls;
using Game.Providers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.GameField
{
    public sealed class GameFieldPresenter : MonoBehaviour, IRandomPointProvider, IGameFieldCenterProvider
    {
        [SerializeField] private BuildersData buildersData;

        public GetRandomPointOnField GetRandomPointOnField => GetRandomPointAtField;
        
        private GameFieldView _view;
        
        private void Start()
        {
            var creator = new GameFieldCreator(buildersData);
            _view = creator.CreateFullScreenFieldView();
            var wallsCreator = new WallsCreator(buildersData, _view);
            wallsCreator.CreateWalls();
        }

        private Vector3 GetRandomPointAtField()
        {
            var mesh = _view.MeshCollider;
            var b = mesh.bounds;

            var x = Random.Range(b.min.x, b.max.x);
            var z = Random.Range(b.min.z, b.max.z);

            var origin = new Vector3(x, b.max.y + 0.1f, z);
            var ray = new Ray(origin, Vector3.down);

            if (mesh.Raycast(ray, out RaycastHit hit, b.size.y + 1f))
            {
                return hit.point + new Vector3(0f, _view.transform.localPosition.y, 0f);
            }
            
            throw new Exception("Can't get random point at the field");
        }

        public Vector3 GetFieldCenter()
        {
            return _view.transform.position;
        }
    }
}