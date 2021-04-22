using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Rigidbody2D rb;
  public float force = 20f;

  void Start()
  {
    rb.AddForce(transform.right * force, ForceMode2D.Impulse);
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(gameObject);
  }
}
