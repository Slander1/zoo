using Game.GameField.Builders.Data;
using UnityEngine;

namespace Game.GameField.Builders.Walls
{
    public sealed class WallsCreator
    {
        private readonly BuildersData _buildersData;
        private readonly GameFieldView _fieldView;

        public WallsCreator(BuildersData buildersData, GameFieldView fieldView)
        {
            _buildersData    = buildersData;
            _fieldView = fieldView;
        }

        public void CreateWalls()
        {
            var bounds = _fieldView.MeshCollider.bounds;
            
            var wallHeight  = 2f;
            var wallThickness = 0.1f;

            var widthX = bounds.size.x;
            var widthZ = bounds.size.z;
            
            var posY = _fieldView.transform.position.y + wallHeight / 2f;
            
            var parent = _buildersData.GameFieldParent;

            CreateWall(
                parent,
                new Vector3(bounds.min.x  - wallThickness * 0.5f,posY, bounds.center.z),
                new Vector3(wallThickness, wallHeight, widthZ)
            );

            CreateWall(
                parent,
                new Vector3(bounds.max.x + wallThickness * 0.5f,  posY, bounds.center.z),
                new Vector3(wallThickness, wallHeight, widthZ)
            );

            CreateWall(
                parent,
                new Vector3(bounds.center.x, posY, bounds.min.z - wallThickness * 0.5f),
                new Vector3(widthX, wallHeight, wallThickness)
            );

            CreateWall(
                parent,
                new Vector3(bounds.center.x, posY, bounds.max.z + wallThickness * 0.5f),
                new Vector3(widthX, wallHeight, wallThickness)
            );
        }

        private void CreateWall(Transform parent, Vector3 position, Vector3 size)
        {
            var wallGO = new GameObject("Wall");
            wallGO.transform.SetParent(parent, worldPositionStays: true);
            wallGO.transform.position = position;
            wallGO.transform.rotation = Quaternion.identity;

            var collider = wallGO.AddComponent<BoxCollider>();
            collider.size = size;

            wallGO.tag = "Wall";
        }
    }
}