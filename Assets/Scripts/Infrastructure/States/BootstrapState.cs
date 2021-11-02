using AmayaTest.Infrastructure.Services;

namespace AmayaTest.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly ServiceContainer _services;
    
    public BootstrapState(GameStateMachine stateMachine, ServiceContainer services)
    {
      _stateMachine = stateMachine;
      _services = services;

      RegisterServices();
    }

    public void RegisterServices()
    {
    }

    public void Exit()
    {
      
    }

    public void Enter()
    {
      
    }
  }
}