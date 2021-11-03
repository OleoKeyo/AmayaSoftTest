using System;
using System.Threading.Tasks;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.LevelGeneration;
using AmayaTest.StaticData.Config;

namespace AmayaTest.BoardLogic
{
  public class GameBoardService : IGameBoardService
  {
    public Action OnChoiceRightAnswer { get; set; }

    private readonly IGameFactory _gameFactory;
    private readonly IConfigService _config;
    private GameBoard _gameBoard;
    private string _rightAnswer;
    private bool _isReadyForCheck;

    public GameBoardService(IGameFactory gameFactory, IConfigService configService)
    {
      _gameFactory = gameFactory;
      _config = configService;
    }
    
    public void Refresh(LevelCardSet cardSet, int difficultLevel)
    {
      if (_gameBoard == null)
      {
        _gameBoard = _gameFactory.CreateGameBoard();
        _gameBoard.Construct(_gameFactory, _config, this);
      }
      
      _gameBoard.Refresh(cardSet, difficultLevel);
      SetRightAnswer(cardSet.WinnerCard.Description);
    }

    public async Task CheckCard(Card clickedCard)
    {
      if(!_isReadyForCheck)
        return;
      
      if (AnswerIsRight(clickedCard.Description))
      {
        await _gameBoard.PlayRightAnswerAnimation(clickedCard.MainImageTransform);
        OnChoiceRightAnswer?.Invoke();
      }
      else
      {
        await _gameBoard.PlayWrongAnswerAnimation(clickedCard.MainImageTransform);
      }
    }

    public void Reset()
    {
      _gameBoard.Clear();
      ResetRightAnswer();
    }

    private bool AnswerIsRight(string answer) =>
      answer == _rightAnswer;

    private void SetRightAnswer(string rightAnswer)
    {
      _rightAnswer = rightAnswer;
      _isReadyForCheck = true;
    }

    private void ResetRightAnswer()
    {
      _rightAnswer = null;
      _isReadyForCheck = false;
    }
  }
}