using CoreLogic.Scenes.Scene;
using VContainer;

namespace CoreLogic.Bootstrap
{
    public sealed class AppBootstrap : GameSceneScope
    {
        #region === Unity Events ===

        private void Start()
        {
            CallSceneCoordinator();
        }        

        #endregion  === Unity Events ===
        
        private void CallSceneCoordinator()
        {
            SceneCoordinator.LoadStartScene();
        }
    }
}