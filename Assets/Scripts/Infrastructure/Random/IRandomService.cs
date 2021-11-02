using AmayaTest.Infrastructure.Services;

namespace AmayaTest.Infrastructure.Random
{
  public interface IRandomService : IService
  {
    int Next(int maxValue);
    int Next(int minValue, int maxValue);
  }
}