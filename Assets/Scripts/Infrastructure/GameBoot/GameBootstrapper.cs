using AmayaTest.Infrastructure.Services;
using AmayaTest.Infrastructure.States;
using UnityEngine;

namespace AmayaTest.Infrastructure.GameBoot
{
  public class GameBootstrapper : MonoBehaviour
  {
    private GameStateMachine _gameStateMachine;

    private void Awake()
    {
      _gameStateMachine =
        new GameStateMachine(new ServiceContainer());
      _gameStateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(this);
    }
  }
}