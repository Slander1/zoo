using CoreLogic.Scenes.Scene;

namespace CoreLogic.Bootstrap
{
    public sealed class AppBootstrap : GameSceneScope
    {
        #region === Unity Events ===

        private void Start()
        {
            LoadStartScene();
        }        

        #endregion  === Unity Events ===
        
        private void LoadStartScene()
        {
            SceneCoordinator.LoadStartScene();
        }
    }
}