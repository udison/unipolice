using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public GameObject player;
  public float health = 100f;

  void Start() {
  }

  void Update() {
  }

  void LookToPlayer() {

  }

  void Attack() {
    // Debug.LogError("Attacking player!");
  }

  public void TakeDamage(float damage) {
    health -= damage;

    if(health <= 0)
      Die();
  }

  void Die() {
    Destroy(gameObject);
  }
}
