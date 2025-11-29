using System;
using CoreLogic.Scenes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreLogic.CoreScope
{
    public sealed class AppCoreScope : LifetimeScope
    {
        [SerializeField] private CoreScopeData data;
        
        protected override void Configure(IContainerBuilder builder)
        {
            if (data == null) throw new NullReferenceException("Data in AppCoreScope is null");
            
            builder.Register<SceneCoordinator>(Lifetime.Singleton)
                .WithParameter(data.ScenesList)
                .As<ISceneCoordinator>();
        }
    }
}
