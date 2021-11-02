using System.Collections.Generic;
using AmayaTest.Infrastructure.Services;

namespace AmayaTest.StaticData.Config
{
  public interface IConfigService : IService
  { 
    Dictionary<string, CardBundleData> Bundles { get;}
    int CardsInLine { get; }
  }
}