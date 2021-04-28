using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public float health;
  public float armor;
  public Text healthText;

  // Start is called before the first frame update
  void Start()
  {
    RefreshUI();
  }

  public void TakeDamage(float damage) {
    health -= Mathf.Ceil(damage - ((armor / 100) * damage));

    if(health <= 0) {
      health = 0;
      Die();
    }

    RefreshUI();
  }

  void Die() {
    Destroy(gameObject);
  }

  void RefreshUI() {
    healthText.text = health.ToString();
  }
}
