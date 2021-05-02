using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public Button retryBtn;
  public Button quitBtn;

  void Start() {
    retryBtn.onClick.AddListener(Retry);
    quitBtn.onClick.AddListener(Quit);
  }

  void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  void Quit() {
    Application.Quit();
  }
}
