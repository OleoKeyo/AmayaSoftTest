using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class CardRenderer : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer _symbol;
    [SerializeField] private SpriteRenderer _background;

    public Transform MainImageTransform => _symbol.transform;

    public void Construct(CardData cardData)
    {
      Quaternion rotation = Quaternion.Euler(0, 0, cardData.ZRotation);
      _symbol.transform.rotation = rotation;
      _symbol.sprite = cardData.Sprite;
      _background.color = cardData.Background;
    }
  }
}