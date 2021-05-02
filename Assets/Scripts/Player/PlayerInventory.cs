using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  public GameObject hand;
  public GameObject primaryWeapon;
  public GameObject secondaryWeapon;
  public Sprite holdingRifle;
  public Sprite holdingPistol;

  private SpriteRenderer spriteRenderer;

  void Start() {
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
}
