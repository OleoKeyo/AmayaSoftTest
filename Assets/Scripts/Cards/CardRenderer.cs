using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class CardRenderer : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer symbol;
    [SerializeField] private SpriteRenderer background;

    public Transform MainImageTransform => symbol.transform;

    public void Construct(CardData cardData)
    {
      Quaternion rotation = Quaternion.Euler(0, 0, cardData.ZRotation);
      symbol.transform.rotation = rotation;
      symbol.sprite = cardData.Sprite;
      background.color = cardData.Background;
    }
  }
}