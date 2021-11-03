using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  [CreateAssetMenu(fileName = "GameConfigData", menuName = "GameConfig")]
  public class GameConfigData : ScriptableObject
  {
    [SerializeField] private int _cardsInLine;
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _firstDifficultLevel;
    [SerializeField] private Vector2 _cardSizeInPixels;
    [SerializeField] private Vector2 _spacing;
    [SerializeField] private int _pixelsPerUnit;
    [SerializeField] private CardBundleData[] _bundles;

    public int CardsInLine => _cardsInLine;
    public int MaxLevel => _maxLevel;
    public int FirstDifficultLevel => _firstDifficultLevel;
    public Vector2 CardSizeInPixels => _cardSizeInPixels;
    public Vector2 Spacing => _spacing;
    public int PixelsPerUnit => _pixelsPerUnit;
    public CardBundleData[] Bundles => _bundles;
  }
}