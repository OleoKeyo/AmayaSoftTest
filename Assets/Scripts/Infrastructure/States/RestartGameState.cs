using AmayaTest.BoardLogic;
using AmayaTest.StaticData.Config;
using AmayaTest.UI.Curtain;

namespace AmayaTest.Infrastructure.States
{
  public class RestartGameState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly CurtainService _curtain;
    private readonly GameBoardService _gameBoardService;
    private readonly ConfigService _config;
    
    public RestartGameState(
      GameStateMachine stateMachine, 
      ConfigService config,
      CurtainService curtain,
      GameBoardService gameBoardService)
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
      _stateMachine.Enter<LoadLevelState, int>(_config.FirstDifficultLevel);
    }

    public void Exit() =>
      _curtain.HideLoadingCurtain();
  }
}