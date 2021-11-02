using System;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class GameBoard : MonoBehaviour
  {
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
          Instantiate(card, spawnPosition, Quaternion.identity, transform);
        }
      }

    }
  }
}