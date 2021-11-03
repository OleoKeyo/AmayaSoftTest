using AmayaTest.BoardLogic;
using AmayaTest.Infrastructure.AssetManagement;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.Infrastructure.Random;
using AmayaTest.Infrastructure.Services;
using AmayaTest.LevelGeneration;
using AmayaTest.StaticData.Config;
using AmayaTest.UI;
using AmayaTest.UI.Curtain;

namespace AmayaTest.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const int FirstDifficultLevel = 1;
    private readonly GameStateMachine _stateMachine;
    private readonly ServiceContainer _services;
    
    public BootstrapState(GameStateMachine stateMachine, ServiceContainer services)
    {
      _stateMachine = stateMachine;
      _services = services;

      RegisterServices();
    }

    public void RegisterServices()
    {
      _services.RegisterSingle<IGameStateMachine>(_stateMachine);
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      _services.RegisterSingle<IRandomService>(new RandomService());
      _services.RegisterSingle<IConfigService>(new ConfigService());
      _services.RegisterSingle<ILevelGeneratorService>(new LevelGeneratorService(
        _services.Resolve<IConfigService>(), 
        _services.Resolve<IRandomService>()));

      _services.RegisterSingle<IGameFactory>(new GameFactory(_services));
      _services.RegisterSingle<IGameBoardService>(new GameBoardService(
        _services.Resolve<IGameFactory>(), 
        _services.Resolve<IConfigService>()));
      
      _services.RegisterSingle<IRestartService>(new RestartService(_services.Resolve<IGameFactory>()));
      _services.RegisterSingle<ICurtainService>(new CurtainService(_services.Resolve<IGameFactory>()));
    }
    
    public void Enter()
    {
      _stateMachine.Enter<LoadLevelState, int>(FirstDifficultLevel);
    }

    public void Exit() { }
  }
}