using System;
using System.Threading.Tasks;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.LevelGeneration;
using TMPro;

namespace AmayaTest.BoardLogic
{
  public class GameBoardService : IGameBoardService
  {
    public Action OnChoiceRightAnswer { get; set; }

    private readonly IGameFactory _gameFactory;
    private GameBoard _gameBoard;
    private string _rightAnswer;
    private bool _isReadyForCheck;

    public GameBoardService(IGameFactory gameFactory) =>
      _gameFactory = gameFactory;

    public async Task Refresh(LevelCardSet cardSet)
    {
      if (_gameBoard == null)
        _gameBoard = _gameFactory.CreateGameBoard();

      await _gameBoard.Refresh(cardSet);
      SetRightAnswer(cardSet.WinnerCard.Description);
    }

    public async Task OnCardClick(Card clickedCard)
    {
      if(!_isReadyForCheck)
        return;
      if (AnswerIsRight(clickedCard.Description))
      {
        await _gameBoard.PlayRightAnswerAnimation(clickedCard.transform);
        OnChoiceRightAnswer?.Invoke();
      }
      else
      {
        _gameBoard.PlayWrongAnswerAnimation(clickedCard.transform);
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