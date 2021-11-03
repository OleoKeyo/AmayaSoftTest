using System.Collections.Generic;
using AmayaTest.Infrastructure.Random;
using AmayaTest.StaticData;

namespace AmayaTest.LevelGeneration
{
  public class CardDealer
  {
    private readonly IRandomService _random;

    private readonly CardSequence _cardSequence;
    private readonly CardSequence _winnerSequence;

    public CardDealer(IRandomService random, CardBundleData bundle)
    {
      _random = random;
      _cardSequence = new CardSequence(_random, bundle);
      _winnerSequence = new CardSequence(_random, bundle);
    }

    public LevelCardSet CreateCardSet(int count)
    {
      List<CardData> cards = new List<CardData>();
      CardData winnerCard = _winnerSequence.GetCard();
      _cardSequence.Remove(winnerCard);

      for (int i = 0; i < count - 1; i++)
      {
        CardData cardData = _cardSequence.GetCard();
        cards.Add(cardData);
      }
      _cardSequence.Reset();

      int randomPosition = _random.Next(0, cards.Count);
      cards.Insert(randomPosition, winnerCard);

      LevelCardSet levelCardSet = new LevelCardSet(winnerCard, cards);
      return levelCardSet;
    }
  }
}