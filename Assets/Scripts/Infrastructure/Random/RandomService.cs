namespace AmayaTest.Infrastructure.Random
{
  public class RandomService : IRandomService
  {
    private readonly System.Random _random;

    public RandomService() =>
      _random = new System.Random();
    
    public int Next(int maxValue) =>
      _random.Next(maxValue);

    public int Next(int minValue, int maxValue) =>
      _random.Next(minValue, maxValue);
  }
}