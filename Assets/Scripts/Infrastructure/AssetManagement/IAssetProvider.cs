using AmayaTest.Infrastructure.Services;
using UnityEngine;

namespace AmayaTest.Infrastructure.AssetManagement
{
  public interface IAssetProvider : IService
  {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Transform parent);
  }
}