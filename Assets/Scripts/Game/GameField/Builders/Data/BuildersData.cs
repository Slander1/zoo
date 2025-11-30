using System;
using UnityEngine;

namespace Game.GameField.Builders.Data
{
    [Serializable]
    public class BuildersData
    {
        [SerializeField] private float baseMeshSize = 10f;
        [SerializeField] private GameFieldView gameFieldPrefab;
        [SerializeField] private Transform gameFieldParent;
        [SerializeField] private Camera targetCamera;

        [Header("Padding from screen edges (%)")]
        [Range(0f, 40f)]
        [SerializeField] private float paddingPercentX = 10f;

        [Range(0f, 40f)]
        [SerializeField] private float paddingPercentY = 5f;

        public float BaseMeshSize => baseMeshSize;
        public GameFieldView GameFieldPrefab => gameFieldPrefab;
        public Transform GameFieldParent => gameFieldParent;
        public Camera TargetCamera => targetCamera;
        public float PaddingPercentX => paddingPercentX;
        public float PaddingPercentY => paddingPercentY;
    }
}