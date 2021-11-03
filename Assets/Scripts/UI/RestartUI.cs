using System;
using System.Threading.Tasks;
using AmayaTest.Infrastructure.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaTest.UI
{
  public class RestartUI : MonoBehaviour
  {
    [SerializeField] private LoadingCurtain curtain;
    [SerializeField] private Button restartButton;
    public Action OnRestart { get; set; }

    public Task Show()
    {
      restartButton.gameObject.SetActive(true);
      return curtain.Show();
    }
    
    public Task Hide()
    {
      restartButton.onClick.RemoveAllListeners();
      return curtain.Hide();
    }

    private void CloseRestartButton()
    {
      restartButton.gameObject.SetActive(false);
    }
  }
}