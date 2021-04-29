using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public Button newGame;
  public Button quit;
  public SpriteRenderer fade;
  public float fadeTime = 2f;
  private bool doFade = false;
  private float time = 0;

  void Start() {
    newGame.onClick.AddListener(NewGame);
    quit.onClick.AddListener(Quit);
  }

  void Update() {
    if(doFade) {
      Color newColor = fade.color;
      newColor.a = Mathf.Lerp(newColor.a, 1, time);

      fade.color = newColor;

      time += 0.05f * Time.deltaTime;
    }
  }

  void NewGame() {
    doFade = true;
    StartCoroutine("NewGameCoroutine");
  }

  IEnumerator NewGameCoroutine() {
    yield return new WaitForSeconds(fadeTime);
    SceneManager.LoadScene("SampleScene");
  }
  
  void Quit() {
    Application.Quit();
  }
}
