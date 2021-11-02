﻿using System.Collections.Generic;
using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  public class ConfigService : IConfigService
  {
    private const string ConfigDataPath = "Config/GameConfigData";

    private Dictionary<string, CardBundleData> _bundles;
    private int _cardsInLine;

    public Dictionary<string, CardBundleData> Bundles => _bundles;
    public int CardsInLine => _cardsInLine;

    public ConfigService()
    {
      GameConfigData config = GetGameConfig();
      _cardsInLine = config.CardsInLine;
      InitBundles(config);
    }

    private void InitBundles(GameConfigData config)
    {
      _bundles = new Dictionary<string, CardBundleData>();
      foreach (CardBundleData bundle in config.Bundles)
      {
        string bundleName = bundle.name;
        _bundles[bundleName] = bundle;
      }
    }

    private GameConfigData GetGameConfig() =>
      Resources.Load<GameConfigData>(ConfigDataPath);

  }
}