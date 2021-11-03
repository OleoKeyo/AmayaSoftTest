using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  [CreateAssetMenu(fileName = "GameConfigData", menuName = "GameConfig")]
  public class GameConfigData : ScriptableObject
  {
    [SerializeField] private int _cardsInLine;
    [SerializeField] private int _maxLevel;
    [SerializeField] private CardBundleData[] _bundles;

    public CardBundleData[] Bundles => _bundles;
    public int CardsInLine => _cardsInLine;
    public int MaxLevel => _maxLevel;
  }
}