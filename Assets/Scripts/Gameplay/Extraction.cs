using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extraction : MonoBehaviour
{
  public string nextLevel;
  
  GameHandler gameHandler;

  void Start() {
    gameHandler = GameHandler.GetGameHandler();
  }

  void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.layer == gameHandler.GetPlayerLayer()) {
      if(gameHandler.IsAllQuestsCompleted()) {
        SceneManager.LoadScene(nextLevel);
      }
    }
  }
}
