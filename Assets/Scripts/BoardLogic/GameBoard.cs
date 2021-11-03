using System.Collections.Generic;
using System.Threading.Tasks;
using AmayaTest.Cards;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.LevelGeneration;
using AmayaTest.StaticData;
using AmayaTest.StaticData.Config;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class GameBoard : MonoBehaviour
  {
    [SerializeField] private StartBounceAnimator _startBounceAnimator;
    [SerializeField] private RightAnswerAnimator _rightAnswerAnimator;
    [SerializeField] private WrongAnswerAnimator _wrongAnswerAnimator;
    [SerializeField] private FadeText _currentTargetText;
    
    private Grid _grid;
    private IGameFactory _gameFactory;
    private IConfigService _config;
    private IGameBoardService _gameBoardService;
    private readonly List<Card> _activeCards = new List<Card>();
    private Vector3[] SpawnPoints => _grid.SpawnPoints;
    
    public void Construct(IGameFactory gameFactory, IConfigService configService, IGameBoardService gameBoardService)
    {
      _gameFactory = gameFactory;
      _config = configService;
      _gameBoardService = gameBoardService;
      _grid = new Grid(_config);
    }
    
    public void Refresh(LevelCardSet cardSet, int difficultLevel)
    {
      SetCurrentTargetText(cardSet.WinnerCard, difficultLevel);
      
      List<CardData> cards = cardSet.Cards;
      
      for (int index = 0; index < cards.Count; index++)
      {
        CardData cardData = cards[index];
        Vector3 spawnPosition = SpawnPoints[index];
        
        if (index < _activeCards.Count)
          UpdateCard(_activeCards[index], cardData);
        else
          CreateNewCard(cardData, spawnPosition, difficultLevel);
      }
    }

    public void Clear()
    {
      foreach (Card activeCard in _activeCards)
        Destroy(activeCard.gameObject);
      
      _activeCards.Clear();
    }

    public async Task PlayRightAnswerAnimation(Transform cardTransform) =>
      await _rightAnswerAnimator.Play(cardTransform);

    public async Task PlayWrongAnswerAnimation(Transform cardTransform) =>
      await _wrongAnswerAnimator.Play(cardTransform);

    private void UpdateCard(Card card, CardData data) =>
      card.UpdateCard(data);

    private void CreateNewCard(CardData cardData, Vector3 position, int difficultLevel)
    {
      Card card = _gameFactory.CreateCard(position, transform);
      card.Construct(_gameBoardService, cardData);
      _activeCards.Add(card);
      
      if(difficultLevel == 1)
        PlayStartBounceAnimation(card.MainImageTransform);
    }

    private void PlayStartBounceAnimation(Transform cardTransform) =>
      _startBounceAnimator.Play(cardTransform);
    
    private void SetCurrentTargetText(CardData winner, int difficultLevel)
    {
      string text = $"Find {winner.Description}";
      if (difficultLevel == 1)
        _currentTargetText.ShowFadedText(text);
      else
        _currentTargetText.ChangeText(text);
    }
  }
}