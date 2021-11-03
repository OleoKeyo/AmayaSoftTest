using AmayaTest.BoardLogic;
using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class Card : MonoBehaviour
  {
    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private CardAnswerChecker _cardAnswerChecker;
    
    private string _description;
    public string Description => _description;

    public Transform MainImageTransform => _cardRenderer.MainImageTransform;

    public void Construct(IGameBoardService gameBoardService, CardData cardData)
    {
      _description = cardData.Description;
      _cardRenderer.Construct(cardData);
      _cardAnswerChecker.Construct(gameBoardService, this);
    }

    public void UpdateCard(CardData cardData)
    {
      _description = cardData.Description;
      _cardRenderer.Construct(cardData);
    }
  }
}