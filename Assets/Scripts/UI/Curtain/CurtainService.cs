using System.Threading.Tasks;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;

namespace AmayaTest.UI.Curtain
{
  public class CurtainService : IService
  {
    private readonly GameFactory _gameFactory;
    private LoadingCurtain _loadingCurtain;

    public CurtainService(GameFactory gameFactory) =>
      _gameFactory = gameFactory;

    public Task ShowLoadingCurtain()
    {
      if (_loadingCurtain == null)
      {
        _loadingCurtain = _gameFactory.CreateLoadingCurtain();
      }
      
      return _loadingCurtain.Show();
    }

    public Task HideLoadingCurtain() =>
      _loadingCurtain.Hide();
  }
}