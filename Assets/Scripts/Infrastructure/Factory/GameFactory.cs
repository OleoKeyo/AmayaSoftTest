﻿using AmayaTest.BoardLogic;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.AssetManagement;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider _assets;

    public GameFactory(ServiceContainer services) =>
      _assets = services.Resolve<IAssetProvider>();

    public Card CreateCard(Vector3 position, Transform parent)
    {
      GameObject prefab = Instantiate(AssetPath.CardPath, position, Quaternion.identity, parent);
      Card card = prefab.GetComponent<Card>();
      return card;
    }

    public GameBoard CreateGameBoard()
    {
      GameObject prefab = Instantiate(AssetPath.GameBoardPath);
      GameBoard gameBoard = prefab.GetComponent<GameBoard>();
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
    
    private GameObject Instantiate(string prefabPath) =>
      _assets.Instantiate(prefabPath);
    
    private GameObject Instantiate(string prefabPath, Vector3 position, Quaternion rotation, Transform parent) =>
      _assets.Instantiate(prefabPath, position, rotation, parent);
  }
}