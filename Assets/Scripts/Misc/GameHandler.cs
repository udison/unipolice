using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
  public GameObject player;
  public PauseMenu pauseMenu;
  public bool isPaused = false;
  private Objectives objectives;

  void Start() {
    objectives = GetComponent<Objectives>();
    Cursor.visible = false;
  }

  void Update() {

    if(Input.GetKeyDown(KeyCode.Escape)) {
      pauseMenu.TogglePauseMenu();
    }
  }

  public bool IsAllQuestsCompleted() {
    Objectives.Quest[] quests = objectives.quests;
    bool ret = true;

    for(int i = 0; i < quests.Length; i++) {
      if(!quests[i].isCompleted) {
        ret = false;
        break;
      }
    }

    return ret;
  }

  public void SetPaused(bool state) {
    isPaused = state;
    Cursor.visible = state;
  }

  public static GameHandler GetGameHandler() {
    return GameObject.Find("_GameHandler").GetComponent<GameHandler>();
  }

  public Player GetPlayer() {
    return player.GetComponent<Player>();
  }

  public GameObject GetPlayerGameObj() {
    return player;
  }

  public Vector3 GetPlayerPosition() {
    return player.transform.position;
  }

  public int GetPlayerLayer() {
    return player.layer;
  }

  // Math functions
  float Normalize(float x, float min, float max) {
    return (x - min) / (max - min);
  }
}
