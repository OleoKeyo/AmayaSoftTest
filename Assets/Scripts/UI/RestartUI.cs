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
    private bool _isReadyForRestart;

    public async Task Show()
    {
      restartButton.gameObject.SetActive(true);
      await curtain.Show();
      _isReadyForRestart = true;
    }
    
    public Task Hide() => 
      curtain.Hide();
    
    public void OnRestartButtonClick()
    {
      if(!_isReadyForRestart)
        return;
      
      OnRestart?.Invoke();
      restartButton.gameObject.SetActive(false);
      _isReadyForRestart = false;
    }
  }
}