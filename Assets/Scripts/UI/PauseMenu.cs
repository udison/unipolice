using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public Button continueBtn;
  public Button quit;
  public GameObject crosshair;

  private GameHandler gameHandler;

  void Start()
  {
    continueBtn.onClick.AddListener(Continue);
    quit.onClick.AddListener(Quit);
  }

  public void TogglePauseMenu() {
    if(gameHandler == null)
      gameHandler = GameHandler.GetGameHandler();

    gameObject.SetActive(!gameObject.active);
    Time.timeScale = gameObject.active ? 0 : 1;
    gameHandler.SetPaused(gameObject.active);
    crosshair.SetActive(!gameObject.active);
  }

  void Continue()
  {
    TogglePauseMenu();
  }

  void Quit()
  {
    Application.Quit();
    // SceneManager.LoadScene("MainMenu");
  }
}
