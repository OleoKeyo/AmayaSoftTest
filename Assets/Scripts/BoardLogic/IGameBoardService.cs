using System;
using System.Threading.Tasks;
using AmayaTest.Infrastructure.Services;
using AmayaTest.LevelGeneration;

namespace AmayaTest.BoardLogic
{
  public interface IGameBoardService : IService
  {
    Action OnChoiceRightAnswer { get; set; }
    Task Refresh(LevelCardSet cardSet);
    void Reset();
  }
}