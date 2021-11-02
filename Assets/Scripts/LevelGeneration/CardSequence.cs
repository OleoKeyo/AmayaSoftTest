using AmayaTest.Infrastructure.Random;
using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.LevelGeneration
{
  public class CardSequence
  {
    private readonly IRandomService _random;

    private readonly CardData[] _sequence;
    private int _lastIndex;

    public CardSequence(IRandomService random, CardBundleData bundle)
    {
      _random = random;
      _sequence = bundle.CardData;
    }

    public CardData GetCard()
    {
      if (_lastIndex >= _sequence.Length) 
        Reset();
      
      int index = GetRandomIndex(_lastIndex, _sequence.Length);

      CardData card = _sequence[index];
      SwapCard(index, _lastIndex);
      return card;
    }

    public void Remove(CardData card)
    {
      for (int index = 0; index < _sequence.Length; index++)
      {
        if (_sequence[index].Description == card.Description)
        {
          SwapCard(index, _lastIndex);
          break;
        }
      }
    }

    public void Reset() =>
      _lastIndex = 0;

    private void SwapCard(int first, int second)
    {
      (_sequence[first], _sequence[second]) = (_sequence[second], _sequence[first]);
      _lastIndex++;
    }

    private int GetRandomIndex(int min, int max) =>
      _random.Next(min, max);
  }
}