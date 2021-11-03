using AmayaTest.BoardLogic;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.AssetManagement;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest.Infrastructure.Factory
{
  public class GameFactory : IService
  {
    private readonly IAssetProvider _assets;

    public GameFactory(ServiceContainer services) =>
      _assets = services.Resolve<IAssetProvider>();

    public Card CreateCard(Vector3 position, Transform parent)
    {
      GameObject prefab = _assets.Instantiate(AssetPath.CardPath, position, Quaternion.identity, parent);
      Card card = prefab.GetComponent<Card>();
      return card;
    }

    public GameBoard CreateGameBoard()
    {
      GameObject prefab = _assets.Instantiate(AssetPath.GameBoardPath);
      GameBoard gameBoard = prefab.GetComponent<GameBoard>();
      return gameBoard;
    }

    public LoadingCurtain CreateLoadingCurtain()
    {
      GameObject prefab = _assets.Instantiate(AssetPath.CurtainPath);
      LoadingCurtain curtain = prefab.GetComponent<LoadingCurtain>();
      return curtain;
    }

    public RestartUI CreateRestartUI()
    {
      GameObject prefab = _assets.Instantiate(AssetPath.RestartUIPath);
      RestartUI restartUI = prefab.GetComponent<RestartUI>();
      return restartUI;
    }
  }
}