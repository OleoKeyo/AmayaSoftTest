using AmayaTest.BoardLogic;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.StaticData;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    Card CreateCard(CardData cardData, Vector3 position, Transform parent);
    GameBoard CreateGameBoard();
    LoadingCurtain CreateLoadingCurtain();
    RestartUI CreateRestartUI();
  }
}