using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  [CreateAssetMenu(fileName = "GameConfigData", menuName = "GameConfig")]
  public class GameConfigData : ScriptableObject
  {
    [SerializeField] private int _cardsInLine;
    [SerializeField] private CardBundleData[] _bundles;

    public CardBundleData[] Bundles => _bundles;
    public int CardsInLine => _cardsInLine;
  }
}