using AmayaTest.BoardLogic;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    GameObject CreateCard(CardData cardData);
    GameBoard CreateGameBoard();
    LoadingCurtain CreateLoadingCurtain();
  }
}