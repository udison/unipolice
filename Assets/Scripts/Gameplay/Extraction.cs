using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extraction : MonoBehaviour
{
  public string nextLevel;
  
  GameHandler gameHandler;
  Stats stats;

  void Start() {
    gameHandler = GameHandler.GetGameHandler();
    stats = GameHandler.GetStats();
  }

  void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.layer == gameHandler.GetPlayerLayer()) {
      if(gameHandler.IsAllQuestsCompleted()) {
        stats.nextLevel = nextLevel;
        SceneManager.LoadScene("MissionEnd");
      }
    }
  }
}
