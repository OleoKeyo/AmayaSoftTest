using AmayaTest.BoardLogic;
using AmayaTest.StaticData.Config;
using AmayaTest.UI.Curtain;

namespace AmayaTest.Infrastructure.States
{
  public class RestartGameState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly ICurtainService _curtain;
    private readonly IGameBoardService _gameBoardService;
    private readonly IConfigService _config;
    
    public RestartGameState(
      GameStateMachine stateMachine, 
      IConfigService config,
      ICurtainService curtain,
      IGameBoardService gameBoardService)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _gameBoardService = gameBoardService;
      _config = config;
    }

    public async void Enter()
    {
      await _curtain.ShowLoadingCurtain();

      _gameBoardService.Reset();
      _stateMachine.Enter<LoadLevelState, int>(_config.FirstLevel);
    }

    public void Exit() =>
      _curtain.HideLoadingCurtain();
  }
}