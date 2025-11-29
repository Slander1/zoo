using VContainer;
using VContainer.Unity;

namespace CoreLogic.Scenes.Scene
{
    public abstract class GameSceneScope : LifetimeScope
    {
        [Inject]
        protected ISceneCoordinator SceneCoordinator;
    }
}