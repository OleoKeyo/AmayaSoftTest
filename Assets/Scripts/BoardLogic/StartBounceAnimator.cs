using DG.Tweening;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class StartBounceAnimator : MonoBehaviour
  {
    [SerializeField] private float animationTimeInSeconds = 1f;
    [SerializeField] private Vector3 punchScaleStrength = new Vector3(1f, 1f, 1f);

    public void Play(Transform cardTransform)
    {
      cardTransform
        .DOPunchScale(punchScaleStrength, animationTimeInSeconds, 0)
        .SetEase(Ease.Linear);
    }

  }
}