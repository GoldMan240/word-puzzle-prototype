using Code.Gameplay.AssetManagment;
using Code.Gameplay.Factory;
using Code.Infrastructure.LevelConfigHandling;
using Zenject;

namespace Code.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<LevelConfigReader>().AsSingle();
        }
    }
}