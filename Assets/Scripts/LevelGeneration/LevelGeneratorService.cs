using System.Collections.Generic;
using AmayaTest.Infrastructure.Random;
using AmayaTest.Infrastructure.Services;
using AmayaTest.StaticData;
using AmayaTest.StaticData.Config;

namespace AmayaTest.LevelGeneration
{
  public class LevelGeneratorService : IService
  {
    private readonly ConfigService _config;
    private readonly IRandomService _random;
    private List<CardDealer> _cardDealers;

    public LevelGeneratorService(ConfigService config, IRandomService random)
    {
      _config = config;
      _random = random;

      CreateCardDealers();
    }

    private void CreateCardDealers()
    {
      _cardDealers = new List<CardDealer>();
      
      foreach (KeyValuePair<string, CardBundleData> cardBundlePair in _config.Bundles)
        _cardDealers.Add(new CardDealer(_random, cardBundlePair.Value));
    }

    public LevelCardSet GenerateLevelConfig(int difficultLevel)
    {
      int randomBundle = _random.Next(_cardDealers.Count);
      int cardsCount = difficultLevel * _config.CardsInLine;
      return _cardDealers[randomBundle].CreateCardSet(cardsCount);
    }
  }
}