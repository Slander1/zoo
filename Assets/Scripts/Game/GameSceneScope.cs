using Game.Animals.Events;
using Game.Animals.Factory;
using Game.GameField;
using Game.Providers;
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
                .As<AnimalsFactory>()
                .As<IAnimalsCreator>();
            // builder.RegisterComponent<AnimalsBehEventProvider>();
        }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}