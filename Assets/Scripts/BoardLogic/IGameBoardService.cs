using System;
using System.Threading.Tasks;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.Services;
using AmayaTest.LevelGeneration;

namespace AmayaTest.BoardLogic
{
  public interface IGameBoardService : IService
  {
    Action OnChoiceRightAnswer { get; set; }
    void Refresh(LevelCardSet cardSet, int difficultLevel);
    void Reset();
    Task CheckCard(Card card);
  }
}