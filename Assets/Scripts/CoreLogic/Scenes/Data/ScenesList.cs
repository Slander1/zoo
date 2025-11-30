using UnityEngine;

namespace CoreLogic.Scenes.Data
{
    [CreateAssetMenu(fileName = "ScenesList", menuName = "ScriptableSettings/Core Logic/Scenes/Scenes List")]
    public sealed class ScenesList : ScriptableObject
    {
        public string[] Scenes => sceneNames;
    
        [SerializeField] private string[] sceneNames;
    }
}