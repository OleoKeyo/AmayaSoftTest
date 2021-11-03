using System;
using UnityEngine;

namespace AmayaTest.StaticData
{
  [Serializable]
  public class CardData
  {
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _background;
    [SerializeField] private float _zRotation;

    public string Description => _description;
    public Sprite Sprite => _sprite;
    public Color Background => _background;
    public float ZRotation => _zRotation;
  }
}