using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  private GameHandler gameHandler;
  public GameObject hand;
  public GameObject primaryWeapon;
  public GameObject secondaryWeapon;
  public GameObject flashlight;
  public Sprite holdingRifle;
  public Sprite holdingPistol;

  private SpriteRenderer spriteRenderer;

  void Start() {
    gameHandler = GameHandler.GetGameHandler();
    spriteRenderer = GetComponent<SpriteRenderer>();

    if(primaryWeapon != null)
      EquipPrimary();
    else
      EquipSecondary();
  }

  void Update() {
    if(Input.GetKeyDown(KeyCode.Alpha1) && primaryWeapon != null)
      EquipPrimary();

    else if(Input.GetKeyDown(KeyCode.Alpha2) && secondaryWeapon != null)
      EquipSecondary();

    if(Input.GetKeyDown(KeyCode.Q) && !gameHandler.isPaused)
      ToggleFlashlight();
  }

  void EquipPrimary() {
    secondaryWeapon.SetActive(false);
    primaryWeapon.SetActive(true);
    primaryWeapon.GetComponent<Weapons>().canShoot = true;
    spriteRenderer.sprite = holdingRifle;
  }

  void EquipSecondary() {
    primaryWeapon.SetActive(false);
    secondaryWeapon.SetActive(true);
    secondaryWeapon.GetComponent<Weapons>().canShoot = true;
    spriteRenderer.sprite = holdingPistol;
  }

  void ToggleFlashlight() {
    flashlight.SetActive(!flashlight.active);
  }
}
