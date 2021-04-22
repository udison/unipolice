using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  public Transform playerPos;

  void Update()
  {
    Vector3 newPos = playerPos.position;
    newPos.z = -10;

    transform.position = newPos;
  }
}
