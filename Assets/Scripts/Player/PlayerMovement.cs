using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
  public Camera cam;

  private Rigidbody2D rb;
  private Vector2 movement;
  private bool isRunning = false;
  private Vector2 mousePos;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    isRunning = Input.GetKey(KeyCode.LeftShift);

    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
  }

  void FixedUpdate() {

    if(movement != Vector2.zero)
      Walk();

    Vector2 lookDir = mousePos - rb.position;
    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    rb.rotation = angle;
  }

  void Walk() {
    Vector2 newMovement = movement;

    if(isRunning)
      newMovement *= 1.6f;

    rb.MovePosition(rb.position + newMovement * moveSpeed * Time.fixedDeltaTime);
  }
}
