using System;
using UnityEngine;

namespace AmayaTest.StaticData
{
  [Serializable]
  public class CardData
  {
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color background;
    [SerializeField] private float zRotation;

    public string Description => description;
    public Sprite Sprite => sprite;
    public Color Background => background;
    public float ZRotation => zRotation;
  }
}