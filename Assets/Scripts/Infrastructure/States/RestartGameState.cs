using AmayaTest.BoardLogic;
using AmayaTest.LevelGeneration;
using AmayaTest.UI.Curtain;

namespace AmayaTest.Infrastructure.States
{
  public class RestartGameState : IState
  {
    private const int FirstDifficultLevel = 1;
    
    private readonly GameStateMachine _stateMachine;
    private readonly ILevelGeneratorService _levelGeneratorService;
    private readonly ICurtainService _curtain;
    private readonly IGameBoardService _gameBoardService;
    
    public RestartGameState(
      GameStateMachine stateMachine, 
      ILevelGeneratorService levelGeneratorService,
      ICurtainService curtain,
      IGameBoardService gameBoardService)
    {
      _stateMachine = stateMachine;
      _levelGeneratorService = levelGeneratorService;
      _curtain = curtain;
      _gameBoardService = gameBoardService;
    }

    public async void Enter()
    {
      await _curtain.ShowLoadingCurtain();

      _gameBoardService.Reset();
      _levelGeneratorService.Reset();
      _stateMachine.Enter<LoadLevelState, int>(FirstDifficultLevel);
    }

    public void Exit()
    {
      
    }
  }
}