using AmayaTest.Infrastructure.Services;

namespace AmayaTest.LevelGeneration
{
  public interface ILevelGeneratorService : IService
  {
    LevelCardSet GenerateLevelConfig(int difficultLevel);
    void Reset();
  }
}