using AmayaTest.StaticData.Config;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class Grid
  {
    public Vector3[] SpawnPoints { get; }

    public Grid(ConfigService config)
    {
      int width = config.CardsInLine;
      int height = config.MaxLevel;
      Vector2 cellSize = (config.CardSizeInPixels + config.Spacing) / config.PixelsPerUnit;
      
      SpawnPoints = new Vector3[width * height];
      int index = 0;
      for (int y = height - 1; y >= 0; y--)
      {
        for (int x = 0; x < width; x++)
        {
          SpawnPoints[index] = new Vector3(x * cellSize.x, y * cellSize.y, 0);
          index++;
        }
      }
    }
  }
}