﻿using AmayaTest.StaticData;
using UnityEngine;

namespace AmayaTest.Cards
{
  public class CardRenderer : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer _symbol;
    [SerializeField] private SpriteRenderer _background;

    public void Construct(CardData cardData)
    {
    }
  }
}