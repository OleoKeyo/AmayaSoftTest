using System;
using System.Threading.Tasks;
using AmayaTest.LevelGeneration;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace AmayaTest.BoardLogic
{
  public class GameBoard : MonoBehaviour
  {
    [SerializeField] private StartBounceAnimator _startBounceAnimator;
    [SerializeField] private RightAnswerAnimator _rightAnswerAnimator;
    [SerializeField] private WrongAnswerAnimator _wrongAnswerAnimator;
    public GameObject card;
    private Grid _grid;

    private void Awake()
    {
      _grid = new Grid(4, 4, new Vector2(6, 6));
      Vector3[,] spawnPoints = _grid.SpawnPoints;
      
      for (int y = spawnPoints.GetLength(1) - 1; y >= 0; y--)
      {
        for (int x = 0; x < spawnPoints.GetLength(0); x++)
        {
          Vector3 spawnPosition = spawnPoints[x, y];
          GameObject cardGo = Instantiate(card, spawnPosition, Quaternion.identity, transform);
          PlayStartBounceAnimation(cardGo.transform);
        }
      }
    }

    public async Task Refresh(LevelCardSet cardSet)
    {
      
    }

    public async Task PlayRightAnswerAnimation(Transform cardTransform)
    {
      await _rightAnswerAnimator.Play(cardTransform);
    }

    public void PlayWrongAnswerAnimation(Transform cardTransform) =>
      _wrongAnswerAnimator.Play(cardTransform);

    private void PlayStartBounceAnimation(Transform cardTransform) =>
      _startBounceAnimator.Play(cardTransform);

    public void Clear()
    {
      
    }
  }
}