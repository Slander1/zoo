using System;
using CoreLogic.Scenes.Data;
using UnityEngine;

namespace CoreLogic.CoreScope
{
    [Serializable]
    [CreateAssetMenu(fileName = "CoreScopeData", menuName = "ScriptableSettings/Core Logic/Bootstrap/Core Scope Data")]
    public class CoreScopeData : ScriptableObject
    {
        public ScenesList ScenesList => scenesList;
    
        [SerializeField] private ScenesList scenesList;
    }
}