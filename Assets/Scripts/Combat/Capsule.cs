using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
  public Rigidbody2D rb;
  public float baseForce = 10f;
  public float baseRotation = 15f;

  void Start()
  {
    float finalForce = baseForce + baseForce * Random.Range(0.65f, 1.35f);
    float finalRot = baseRotation + baseRotation * Random.Range(0.65f, 1.35f);

    rb.AddForce(transform.up * finalForce, ForceMode2D.Impulse);
    rb.AddTorque(-finalRot, ForceMode2D.Impulse);
    StartCoroutine("DisablePhysics");
  }

  IEnumerator DisablePhysics()
  {
    yield return new WaitForSeconds(0.5f);
    Destroy(GetComponent<Rigidbody2D>());
    Destroy(GetComponent<Collider2D>());
  }
}
