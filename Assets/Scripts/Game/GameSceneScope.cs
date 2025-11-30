using Game.Animals.Behaviour;
using Game.Animals.Behaviour.Collisions;
using Game.Animals.Events;
using Game.Animals.Factory;
using Game.Animals.Pool;
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
            .As<IRandomPointProvider>()
            .As<IGameFieldCenterProvider>();
            
            builder.RegisterComponentInHierarchy<AnimalsFactory>()
                .As<AnimalsFactory>()
                .As<IAnimalsCreator>();
            
            // builder.RegisterComponentInHierarchy<CollisionProvider>();
            builder.Register<AnimalsPool>(Lifetime.Scoped).As<IAnimalsHashSetProvider>();

            // builder.RegisterEntryPoint<CollisionProvider>();
        }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}