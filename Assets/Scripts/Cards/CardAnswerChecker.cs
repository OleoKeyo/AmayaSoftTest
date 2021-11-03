using AmayaTest.BoardLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmayaTest.Cards
{
  public class CardAnswerChecker : MonoBehaviour, IPointerClickHandler
  {
    private GameBoardService _gameBoardService;
    private Card _card;
    private bool _isClicked;

    public void Construct(GameBoardService gameBoardService, Card card)
    {
      _gameBoardService = gameBoardService;
      _card = card;
    }

    public async void OnPointerClick(PointerEventData eventData)
    {
      if(_isClicked)
        return;

      _isClicked = true;
      await _gameBoardService.CheckCard(_card);
      _isClicked = false;
    }
  }
}