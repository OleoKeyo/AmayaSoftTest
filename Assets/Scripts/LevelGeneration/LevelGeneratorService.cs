using System.Collections.Generic;
using AmayaTest.Infrastructure.Random;
using AmayaTest.StaticData;
using AmayaTest.StaticData.Config;

namespace AmayaTest.LevelGeneration
{
  public class LevelGeneratorService : ILevelGeneratorService
  {
    private readonly IConfigService _config;
    private readonly IRandomService _random;

    private List<CardDealer> _cardDealers;

    public LevelGeneratorService(IConfigService config, IRandomService random)
    {
      _config = config;
      _random = random;

      CreateCardDealers();
    }

    private void CreateCardDealers()
    {
      _cardDealers = new List<CardDealer>();
      
      foreach (KeyValuePair<string, CardBundleData> cardBundlePair in _config.Bundles)
        _cardDealers.Add(new CardDealer(_config, _random, cardBundlePair.Value));
    }

    public LevelCardSet GenerateLevelConfig(int difficultLevel)
    {
      int randomBundle = _random.Next(_cardDealers.Count);
      int cardsCount = difficultLevel * _config.CardsInLine;
      return _cardDealers[randomBundle].CreateCardSet(cardsCount);
    }

    public void Reset()
    {
      foreach (CardDealer cardDealer in _cardDealers)
        cardDealer.Reset();
    }
  }
}