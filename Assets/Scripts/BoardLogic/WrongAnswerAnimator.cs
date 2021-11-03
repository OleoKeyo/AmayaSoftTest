using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class WrongAnswerAnimator : MonoBehaviour
  {
    [SerializeField] private float animationTimeInSeconds = 1f;
    [SerializeField] private Vector3 punchPositionStrength = new Vector3(1f, 0f, 0f);
    private Tween _wrongAnswerTween;

    public async Task Play(Transform cardTransform)
    {
      _wrongAnswerTween = cardTransform
        .DOShakeScale(animationTimeInSeconds, punchPositionStrength)
        .SetEase(Ease.InBounce);
      
      await _wrongAnswerTween.AsyncWaitForCompletion();
    }
  }
}