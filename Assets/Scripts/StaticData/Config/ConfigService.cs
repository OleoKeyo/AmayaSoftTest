using System.Collections.Generic;
using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  public class ConfigService : IConfigService
  {
    private const string ConfigDataPath = "Config/GameConfigData";

    private Dictionary<string, CardBundleData> _bundles;
    private readonly int _cardsInLine;
    private readonly int _maxLevel;
    private readonly int _firstDifficultLevel;
    private readonly Vector2 _cardSizeInPixels;
    private readonly Vector2 _spacing;
    private readonly int _pixelsPerUnit;

    public Dictionary<string, CardBundleData> Bundles => _bundles;
    public int CardsInLine => _cardsInLine;
    public int MaxLevel => _maxLevel;
    public int FirstDifficultLevel => _firstDifficultLevel;
    public int FirstLevel => FirstDifficultLevel;
    public Vector2 CardSizeInPixels => _cardSizeInPixels;
    public Vector2 Spacing => _spacing;
    public int PixelsPerUnit => _pixelsPerUnit;

    public ConfigService()
    {
      GameConfigData config = GetGameConfig();
      _cardsInLine = config.CardsInLine;
      _maxLevel = config.MaxLevel;
      _firstDifficultLevel = config.FirstDifficultLevel;
      _cardSizeInPixels = config.CardSizeInPixels;
      _spacing = config.Spacing;
      _pixelsPerUnit = config.PixelsPerUnit;
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