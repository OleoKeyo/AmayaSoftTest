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
    [SerializeField] private bool _isNeededToRotate;

    public string Description => _description;
    public Sprite Sprite => _sprite;
    public Color Background => _background;
    public bool IsNeededToRotate => _isNeededToRotate;
  }
}