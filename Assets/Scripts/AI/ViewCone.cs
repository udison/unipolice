using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCone : MonoBehaviour
{
  public GameObject enemy;
  public GameObject player;
  public LayerMask ignoreLayers;

  void Update() {
  }

  void OnTriggerStay2D(Collider2D collision) {
    Vector2 enemyPos = enemy.transform.position;        // Enemy position
    Vector2 playerPos = player.transform.position;      // Player position
    Vector2 dir = (playerPos - enemyPos).normalized;    // Normalized direction from enemy to player
    float dist = Vector2.Distance(enemyPos, playerPos); // Distance from enemy to player

    // Raycasts to player
    RaycastHit2D hit = Physics2D.Raycast(enemyPos, dir, dist, ~ignoreLayers);

    // If ray hits the player, attacks the player
    if(hit) {
      if(hit.transform.gameObject == player)
        enemy.GetComponent<Enemy>().SendMessage("Attack");
    }
  }

  void OnDrawGizmos() {
    
  }
}
