using AmayaTest.BoardLogic;
using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class Card : MonoBehaviour
  {
    [SerializeField] private CardRenderer cardRenderer;
    [SerializeField] private CardAnswerChecker cardAnswerChecker;
    
    private string _description;
    public string Description => _description;

    public Transform MainImageTransform => cardRenderer.MainImageTransform;

    public void Construct(GameBoardService gameBoardService, CardData cardData)
    {
      _description = cardData.Description;
      cardRenderer.Construct(cardData);
      cardAnswerChecker.Construct(gameBoardService, this);
    }

    public void UpdateCard(CardData cardData)
    {
      _description = cardData.Description;
      cardRenderer.Construct(cardData);
    }
  }
}