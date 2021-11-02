using System.Threading.Tasks;
using AmayaTest.Infrastructure.Services;

namespace AmayaTest.UI.Curtain
{
  public interface ICurtainService : IService
  {
    public Task ShowLoadingCurtain();
    public Task HideLoadingCurtain();
  }
}