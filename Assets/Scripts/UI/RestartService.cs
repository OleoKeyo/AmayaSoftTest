using System;
using System.Threading.Tasks;
using AmayaTest.Infrastructure.Factory;

namespace AmayaTest.UI
{
  public class RestartService : IRestartService
  {
    private IGameFactory _gameFactory;
    private RestartUI _restartUI;

    public Action OnRestart
    {
      get => _restartUI.OnRestart;
      set => _restartUI.OnRestart = value;
    }

    public RestartService(IGameFactory gameFactory) =>
      _gameFactory = gameFactory;
    
    public Task ShowMenu()
    {
      if (_restartUI == null)
        _restartUI = _gameFactory.CreateRestartUI();

      return _restartUI.Show();
    }

    public Task HideMenu() =>
      _restartUI.Hide();
  }
}