using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  [CreateAssetMenu(fileName = "GameConfigData", menuName = "GameConfig")]
  public class GameConfigData : ScriptableObject
  {
    [SerializeField] private int cardsInLine;
    [SerializeField] private int maxLevel;
    [SerializeField] private int firstDifficultLevel;
    [SerializeField] private Vector2 cardSizeInPixels;
    [SerializeField] private Vector2 spacing;
    [SerializeField] private int pixelsPerUnit;
    [SerializeField] private CardBundleData[] bundles;

    public int CardsInLine => cardsInLine;
    public int MaxLevel => maxLevel;
    public int FirstDifficultLevel => firstDifficultLevel;
    public Vector2 CardSizeInPixels => cardSizeInPixels;
    public Vector2 Spacing => spacing;
    public int PixelsPerUnit => pixelsPerUnit;
    public CardBundleData[] Bundles => bundles;
  }
}