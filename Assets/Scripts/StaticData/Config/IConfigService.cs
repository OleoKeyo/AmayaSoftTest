﻿using System.Collections.Generic;
using AmayaTest.Infrastructure.Services;
using UnityEngine;

namespace AmayaTest.StaticData.Config
{
  public interface IConfigService : IService
  { 
    Dictionary<string, CardBundleData> Bundles { get;}
    int CardsInLine { get; }
    int MaxLevel { get; }
    int FirstLevel { get; }
    Vector2 CardSizeInPixels { get; }
    Vector2 Spacing { get; }
    int PixelsPerUnit { get; }
  }
}