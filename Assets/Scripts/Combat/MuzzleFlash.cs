using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
  void Start()
  {
    StartCoroutine("Delete");
  }

  IEnumerator Delete() {
    yield return new WaitForSeconds(0.05f);
    Destroy(gameObject);
  }
}
