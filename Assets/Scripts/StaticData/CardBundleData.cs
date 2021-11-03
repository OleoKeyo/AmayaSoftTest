using UnityEngine;

namespace AmayaTest.StaticData
{
  [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data")]
  public class CardBundleData : ScriptableObject
  {
    [SerializeField] private CardData[] cardData;
    
    public CardData[] CardData => cardData;
  }
}