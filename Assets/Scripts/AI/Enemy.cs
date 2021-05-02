using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private GameHandler gameHandler;
  public GameObject hand;
  public float health = 100f;
  private Weapons equippedWeapon;
  private Rigidbody2D rb;
  private float attackDuration;
  private bool canAttack = true;
  private bool atkCoroutineStarted = false;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    equippedWeapon = hand.transform.GetComponentInChildren<Weapons>();
    attackDuration = Random.Range(0.8f, 1.4f);
    gameHandler = GameHandler.GetGameHandler();
  }

  void Update() {
  }

  void LookToPlayer() {
    Vector2 dir = gameHandler.GetPlayerPosition() - transform.position;
    
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    rb.rotation = Mathf.LerpAngle(rb.rotation, angle, 5f * Time.deltaTime);
  }

  void Attack() {
    LookToPlayer();

    if(canAttack) {
      equippedWeapon.Shoot();
    }

    if(!atkCoroutineStarted) {
      StartCoroutine("AttackAlternation");
      atkCoroutineStarted = true;
    }
  }

  IEnumerator AttackAlternation() {
    yield return new WaitForSeconds(attackDuration);
    canAttack = !canAttack;
    atkCoroutineStarted = false;
  }

  public void TakeDamage(float damage) {
    health -= damage;

    if(health <= 0)
      Die();
  }

  void Die() {
    gameHandler.GetComponent<Objectives>().SendMessage("UpdateQuestObjective", Objectives.QuestType.KILL_ENEMIES);
    Destroy(gameObject);
  }
}
