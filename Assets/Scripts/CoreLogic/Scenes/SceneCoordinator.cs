using System;
using CoreLogic.Scenes.Data;
using UnityEngine.SceneManagement;

namespace CoreLogic.Scenes
{
    public sealed class SceneCoordinator : ISceneCoordinator
    {
        private readonly ScenesList _scenesList;
        
        public SceneCoordinator(ScenesList scenesList)
        {
            _scenesList = scenesList;
        }

        public void LoadStartScene()
        {
            if (_scenesList.Scenes == null || _scenesList.Scenes.Length == 0) 
                throw new ArgumentException("_scenesList.Scenes is null or empty in SceneCoordinator");
            
            LoadSingleScene(_scenesList.Scenes[0]);
        }

        private void LoadSingleScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}