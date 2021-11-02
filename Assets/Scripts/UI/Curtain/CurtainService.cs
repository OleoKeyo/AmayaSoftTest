using System.Threading.Tasks;
using AmayaTest.Infrastructure;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.Infrastructure.SceneManagement;

namespace AmayaTest.UI.Curtain
{
  public class CurtainService : ICurtainService
  {
    private readonly IGameFactory _gameFactory;
    private LoadingCurtain _loadingCurtain;

    public CurtainService(IGameFactory gameFactory)
    {
      _gameFactory = gameFactory;
    }
    
    public void ShowLoadingCurtain()
    {
      if (_loadingCurtain == null)
      {
        _loadingCurtain = _gameFactory.CreateLoadingCurtain();
      }
      
      _loadingCurtain.Show();
    }

    public void HideLoadingCurtain() =>
      _loadingCurtain.Hide();
  }
}