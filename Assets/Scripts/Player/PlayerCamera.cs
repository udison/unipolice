using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  Transform playerTransform;
  Vector3 velocity;

  void Start() {
    playerTransform = GameHandler.GetGameHandler().GetPlayer().transform;
  }

  void Update()
  {
    Vector3 playerPos = playerTransform.position;
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    float maxScreenPoint = 0.8f;

    Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
    Vector3 position = (playerPos + Camera.main.ScreenToWorldPoint(mousePos)) / 2f;
    Vector3 destination = new Vector3(position.x, position.y, -10);
    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, .4f);
  }
}
