using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
  public Transform firePoint;
  public Transform ejectorPoint;
  public GameObject bulletPrefab;
  public GameObject capsulePrefab;

  void Update()
  {
    if(Input.GetButtonDown("Fire1")) {
      Shoot();
    }
  }

  void Shoot() {
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Instantiate(capsulePrefab, ejectorPoint.position, ejectorPoint.rotation);
  }
}
