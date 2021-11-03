using AmayaTest.BoardLogic;
using AmayaTest.LevelGeneration;
using AmayaTest.StaticData.Config;

namespace AmayaTest.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<int>
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly LevelGeneratorService _levelGeneratorService;
    private readonly ConfigService _configService;
    private readonly GameBoardService _gameBoardService;

    private int _difficultLevel;
    
    public LoadLevelState(
      GameStateMachine gameStateMachine,
      LevelGeneratorService levelGeneratorService,
      ConfigService configService,
      GameBoardService gameBoardService)
    {
      _gameStateMachine = gameStateMachine;
      _levelGeneratorService = levelGeneratorService;
      _configService = configService;
      _gameBoardService = gameBoardService;
    }

    public void Enter(int difficultLevel)
    {
      _difficultLevel = difficultLevel;
      LevelCardSet cardSet = _levelGeneratorService.GenerateLevelConfig(_difficultLevel);
      _gameBoardService.Refresh(cardSet, difficultLevel);
      _gameBoardService.OnChoiceRightAnswer += LoadNextLevel;
    }

    public void Exit() =>
      _gameBoardService.OnChoiceRightAnswer -= LoadNextLevel;

    private void LoadNextLevel()
    {
      if(_difficultLevel == _configService.MaxLevel)
        _gameStateMachine.Enter<EndGameState>();
      else
        _gameStateMachine.Enter<LoadLevelState, int>(_difficultLevel + 1);
    }
  }
}