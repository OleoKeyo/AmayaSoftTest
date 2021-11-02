using System.Collections.Generic;
using AmayaTest.StaticData;

namespace AmayaTest.LevelGeneration
{
  public class LevelCardSet
  {
    private CardData _winnerCard;
    private List<CardData> _cards;
    
    public CardData WinnerCard => _winnerCard;
    public List<CardData> Cards => _cards;

    public LevelCardSet(CardData winnerCard, List<CardData> cards)
    {
      _winnerCard = winnerCard;
      _cards = cards;
    }
  }
}