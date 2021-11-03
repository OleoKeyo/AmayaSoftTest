using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class Card : MonoBehaviour
  {
    [SerializeField] private CardRenderer _cardRenderer;
    private string _description;
    public string Description => _description;

    public void Construct(CardData cardData)
    {
      _description = cardData.Description;
      _cardRenderer.Construct(cardData);
    }
  }
}