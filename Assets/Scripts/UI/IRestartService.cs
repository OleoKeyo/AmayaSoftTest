using System;
using System.Threading.Tasks;
using AmayaTest.Infrastructure.Services;

namespace AmayaTest.UI
{
  public interface IRestartService : IService
  {
    Action OnRestart { get; set; }
    Task ShowMenu();
    Task HideMenu();
  }
}