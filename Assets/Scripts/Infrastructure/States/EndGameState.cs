using AmayaTest.UI;

namespace AmayaTest.Infrastructure.States
{
  public class EndGameState : IState
  {
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IRestartService _restartService;

    public EndGameState(GameStateMachine gameStateMachine, IRestartService restartService)
    {
      _gameStateMachine = gameStateMachine;
      _restartService = restartService;
    }

    public async void Enter()
    {
      await _restartService.ShowMenu();
      _restartService.OnRestart += RestartGame;
    }
    
    private async void RestartGame()
    {
      await _restartService.HideMenu();
      _restartService.OnRestart -= RestartGame;
      _gameStateMachine.Enter<RestartGameState>();
    }
    
    public void Exit() { }
  }
}