using System.Collections.Generic;
using AmayaTest.Infrastructure.Services;
using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  public class ConfigService : IService
  {
    private const string ConfigDataPath = "Config/GameConfigData";


    public Dictionary<string, CardBundleData> Bundles => _bundles;
    public int CardsInLine => _config.CardsInLine;
    public int MaxLevel => _config.MaxLevel;
    public int FirstDifficultLevel => _config.FirstDifficultLevel;
    public Vector2 CardSizeInPixels => _config.CardSizeInPixels;
    public Vector2 Spacing => _config.Spacing;
    public int PixelsPerUnit => _config.PixelsPerUnit;

    private Dictionary<string, CardBundleData> _bundles;
    private readonly GameConfigData _config;

    public ConfigService()
    {
      _config = GetGameConfig();
      InitBundles();
    }

    private void InitBundles()
    {
      _bundles = new Dictionary<string, CardBundleData>();
      foreach (CardBundleData bundle in _config.Bundles)
      {
        string bundleName = bundle.name;
        _bundles[bundleName] = bundle;
      }
    }

    private GameConfigData GetGameConfig() =>
      Resources.Load<GameConfigData>(ConfigDataPath);
  }
}