using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsBook : MonoBehaviour
{
  public Text rank;
  public Text statsText;
  public Button continueBtn;
  Stats stats;

  public Image fade;
  public float fadeTime = 2f;
  private bool doFade = false;
  private float time = 0;

  void Start()
  {
    Cursor.visible = true;
    stats = GameHandler.GetStats();
    rank.text = stats.GetRank();
    statsText.text = stats.GetStats();

    continueBtn.onClick.AddListener(Continue);
  }

  void Update() {
    if(doFade) {
      Color newColor = fade.color;
      newColor.a = Mathf.Lerp(newColor.a, 1, time);

      fade.color = newColor;

      time += 0.05f * Time.deltaTime;
    }
  }

  void Continue() {
    fade.gameObject.SetActive(true);
    doFade = true;
    StartCoroutine("ContinueCoroutine");
  }

  IEnumerator ContinueCoroutine() {
    yield return new WaitForSeconds(fadeTime);
    SceneManager.LoadScene(stats.nextLevel);
  }
}
