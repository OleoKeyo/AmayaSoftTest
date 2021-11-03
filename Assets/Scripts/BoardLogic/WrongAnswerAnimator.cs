using DG.Tweening;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class WrongAnswerAnimator : MonoBehaviour
  {
    [SerializeField] private float animationTimeInSeconds = 1f;
    [SerializeField] private Vector3 punchPositionStrength = new Vector3(10f, 0f, 0f);

    public void Play(Transform cardTransform)
    {
      cardTransform
        .DOPunchScale(punchPositionStrength, animationTimeInSeconds, 0)
        .SetEase(Ease.InBounce);
    }
  }
}