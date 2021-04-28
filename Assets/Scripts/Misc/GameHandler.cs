using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
  public GameObject player;

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
}
