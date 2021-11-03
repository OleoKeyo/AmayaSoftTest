using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AmayaTest.BoardLogic
{
  public class FadeText : MonoBehaviour
  {
    [SerializeField] private TMP_Text text;
    [SerializeField] private float maxTextAlpha;
    [SerializeField] private float fadeAnimationTime;
    
    private Tween _doFadeOut;

    private void Awake() =>
      InitFadeTween();

    public void ShowFadedText(string message)
    {
      text.text = message;
      text.alpha = 0f;
      gameObject.SetActive(true);
      PlayFadeTween();
    }

    public void ChangeText(string message) =>
      text.text = message;

    private void InitFadeTween()
    {
      _doFadeOut = text
        .DOFade(maxTextAlpha, fadeAnimationTime)
        .SetAutoKill(false)
        .Pause();
    }

    private void PlayFadeTween() =>
      _doFadeOut.Restart();
  }
}