using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public float health;
  public float armor;
  public Text healthText;

  public GameObject pauseMenu;
  public GameObject gameOver;
  public GameObject crosshair;

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
    Destroy(pauseMenu);
    crosshair.SetActive(false);
    gameOver.SetActive(true);
    Cursor.visible = true;

    Destroy(gameObject);
  }

  void RefreshUI() {
    healthText.text = health.ToString();
  }
}
