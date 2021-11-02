using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class Grid
  {
    private int _width;
    private int _height;
    private Vector2 _cellSize;
    private Vector3[,] _spawnPoints;

    public Vector3[,] SpawnPoints => _spawnPoints;

    public Grid(int width, int height, Vector2 cellSize)
    {
      _spawnPoints = new Vector3[width, height];

      for (int y = _spawnPoints.GetLength(1) - 1; y >= 0; y--)
      {
        for (int x = 0; x < _spawnPoints.GetLength(0); x++)
        {
          _spawnPoints[x, y] = new Vector3(x * cellSize.x, y * cellSize.y, 0);
        }
      }
    }
  }
}