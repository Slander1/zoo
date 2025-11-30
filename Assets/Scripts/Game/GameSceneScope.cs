using Game.Animals.EventHub;
using Game.Animals.Factory;
using Game.Animals.Pool;
using Game.Animals.StatCounters;
using Game.GameField;
using Game.UI.UpPanel;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameSceneScope : CoreLogic.Scenes.Scene.GameSceneScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameFieldPresenter>()
                .As<GameFieldPresenter>()
                .As<IRandomPointProvider>();

            builder.RegisterComponentInHierarchy<AnimalsFactory>()
                .As<AnimalsFactory>();

            builder.RegisterComponentInHierarchy<UpPanelPresenter>();
            
            builder.Register<AnimalsEventHub>(Lifetime.Scoped)
                .As<IAnimalsEventHub>();

            builder.RegisterEntryPoint<DiedCounter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<AnimalsPool>(Lifetime.Scoped)
                .As<IObjectPoolProvider>();
        }
    }
}