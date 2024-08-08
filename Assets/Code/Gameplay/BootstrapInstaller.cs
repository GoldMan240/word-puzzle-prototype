using System;
using Code.Gameplay.AssetManagment;
using Code.Gameplay.Factory;
using Zenject;

namespace Code.Gameplay
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
    }
}