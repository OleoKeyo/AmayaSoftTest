using System;
using System.Threading.Tasks;
using AmayaTest.Infrastructure.Factory;
using AmayaTest.Infrastructure.Services;

namespace AmayaTest.UI
{
  public class RestartService : IService
  {
    private readonly GameFactory _gameFactory;
    private RestartUI _restartUI;

    public Action OnRestart
    {
      get => _restartUI.OnRestart;
      set => _restartUI.OnRestart = value;
    }

    public RestartService(GameFactory gameFactory) =>
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