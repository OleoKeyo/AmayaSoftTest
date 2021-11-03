using AmayaTest.BoardLogic;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.AssetManagement;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.StaticData;
using AmayaTest.StaticData.Config;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly ServiceContainer _services;
    private readonly IAssetProvider _assets;
    private readonly IConfigService _config;
    private Transform _uiRoot;

    public GameFactory(ServiceContainer services)
    {
      _services = services;
      _assets = _services.Resolve<IAssetProvider>();
      _config = _services.Resolve<IConfigService>();
    }

    public Card CreateCard(CardData cardData, Vector3 position, Transform parent)
    {
      GameObject prefab = Instantiate(AssetPath.CardPath, position, Quaternion.identity, parent);
      Card card = prefab.GetComponent<Card>();
      card.Construct(cardData);
      return card;
    }

    public GameBoard CreateGameBoard()
    {
      GameObject prefab = Instantiate(AssetPath.GameBoardPath);
      GameBoard gameBoard = prefab.GetComponent<GameBoard>();
      gameBoard.Construct(this, _config);
      return gameBoard;
    }

    public LoadingCurtain CreateLoadingCurtain()
    {
      GameObject prefab = Instantiate(AssetPath.CurtainPath);
      LoadingCurtain curtain = prefab.GetComponent<LoadingCurtain>();
      return curtain;
    }

    public RestartUI CreateRestartUI()
    {
      GameObject prefab = Instantiate(AssetPath.RestartUIPath);
      RestartUI restartUI = prefab.GetComponent<RestartUI>();
      return restartUI;
    }
    
    private void CreateUIRoot()
    {
      GameObject root = Instantiate(AssetPath.UIRootPath);
      _uiRoot = root.transform;
    }
    
    private GameObject Instantiate(string prefabPath) =>
      _assets.Instantiate(prefabPath);

    private GameObject Instantiate(string prefabPath, Transform parent) => 
      _assets.Instantiate(prefabPath, parent);

    private GameObject Instantiate(string prefabPath, Vector3 position, Quaternion rotation, Transform parent) =>
      _assets.Instantiate(prefabPath, position, rotation, parent);
  }
}