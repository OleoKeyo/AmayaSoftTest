using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class RightAnswerAnimator : MonoBehaviour
  {
    [SerializeField] private float animationTimeInSeconds = 1f;
    [SerializeField] private Vector3 punchScaleStrength = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private GameObject starsParticle;
    
    private Tween _rightAnswerTween;
    
    public async Task Play(Transform cardTransform)
    {
      Instantiate(starsParticle, cardTransform.position, Quaternion.identity);
      
      _rightAnswerTween = cardTransform
        .DOPunchScale(punchScaleStrength, animationTimeInSeconds, 0)
        .SetEase(Ease.InBounce);
      
      await _rightAnswerTween.AsyncWaitForCompletion();
    }
    
  }
}