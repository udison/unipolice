using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
  void Update()
  {
    gameObject.transform.position = Input.mousePosition;
  }
}
