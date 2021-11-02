using System;
using AmayaTest.Infrastructure.SceneManagement;
using AmayaTest.Infrastructure.Services;
using AmayaTest.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AmayaTest.Infrastructure.GameBoot
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    [SerializeField] private LoadingCurtain _curtainPrefab;

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