using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
  public Transform firePoint;
  public Transform ejectorPoint;
  public GameObject bulletPrefab;
  public GameObject capsulePrefab;
  public GameObject muzzleFlashPrefab;

  public float damage;
  public int magSize = 18;
  public int maxAmmo = 144;
  private float reloadTime;

  public float fireRate = 10; // In bullets per second
  public bool singleFire = true;
  public bool burstFire = false;
  public bool fullAuto = false;

  public Text ammoCounter;

  private AudioSource audioSource;
  public AudioClip shotSound;
  public AudioClip reloadSound;

  private int ammo;
  private int remainingAmmo;

  private enum fireModes {
    SINGLE,
    BURST,
    FULLAUTO
  }

  public enum types {
    PISTOL,
    RIFLE
  }
  public types type;

  private fireModes fireMode = fireModes.SINGLE;
  private float timeBetweenShots;
  private float cooldown;
  public bool canShoot = true;
  private bool heldByPlayer = false;
  private Stats stats;

  private GameHandler gameHandler;

  void Start() {
    gameHandler = GameHandler.GetGameHandler();
    if(transform.parent.transform.parent.tag == "Player")
      heldByPlayer = true;

    fireMode = fullAuto ? fireModes.FULLAUTO : singleFire ? fireModes.SINGLE : fireModes.BURST;
    timeBetweenShots = 1 / fireRate;

    ammo = magSize;
    remainingAmmo = maxAmmo;
    reloadTime = reloadSound.length;
    audioSource = GetComponent<AudioSource>();
    stats = GameHandler.GetStats();
  }

  void Update()
  {
    if(heldByPlayer && !gameHandler.isPaused) {

      // If fire mode is SINGLE or BURST and PRESSED fire1 OR
      //    fire mode is FULL AUTO and HOLD DOWN fire1
      if(((fireMode == fireModes.SINGLE || fireMode == fireModes.BURST) && Input.GetButtonDown("Fire1")) ||
          (fireMode == fireModes.FULLAUTO && Input.GetButton("Fire1"))) {
        Shoot();
      }

      // If press 'B' go to next firemode
      if(Input.GetKeyDown(KeyCode.B)) {
        NextFireMode();
      }

      // If press 'R' reload the weapon
      if(Input.GetKeyDown(KeyCode.R)) {
        Reload();
      }
    }
  }

  public void Shoot() {
    if(canShoot && ammo > 0) {
      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      bullet.GetComponent<Bullet>().damage = damage;
      Instantiate(capsulePrefab, ejectorPoint.position, ejectorPoint.rotation);
      Instantiate(muzzleFlashPrefab, ejectorPoint.position, new Quaternion(ejectorPoint.rotation.x, ejectorPoint.rotation.y, ejectorPoint.rotation.z, 0));
      PlaySound(shotSound);

      if(heldByPlayer) {
        stats.shots++;

        if(type == types.RIFLE)
          stats.shotWithRifle = true;
        else
          stats.shotWithPistol = true;
      }
      
      ammo--;
      if(ammo == 0) {
        if(remainingAmmo > 0)
          Reload();
        else
          canShoot = false;
      }
      else
        SetCooldown(timeBetweenShots);

      RefreshGUI();
    }
  }

  void Reload() {
    if(remainingAmmo > 0 && ammo != magSize) {
      PlaySound(reloadSound);
      StartCoroutine("ReloadCoroutine");
    }
  }

  IEnumerator ReloadCoroutine() {
    yield return new WaitForSeconds(reloadTime);

    int spaceAvailable = magSize - ammo;
    if(spaceAvailable <= remainingAmmo) {
      ammo += spaceAvailable;
      remainingAmmo -= spaceAvailable;
    }
    else {
      ammo = remainingAmmo;
      remainingAmmo = 0;
    }
    RefreshGUI();
  }

  void SetCooldown(float cooldown) {
    canShoot = false;
    StartCoroutine("CanShootCoroutine", cooldown);
  }

  IEnumerator CanShootCoroutine(float cooldown) {
    yield return new WaitForSeconds(cooldown);
    canShoot = true;
    RefreshGUI();
  }

  void RefreshGUI() {
    if(heldByPlayer)
      ammoCounter.text = ammo + "/" + remainingAmmo;
  }

  void NextFireMode() {
    if(fireMode == fireModes.SINGLE) {
      fireMode = burstFire ? fireModes.BURST    : 
                 fullAuto  ? fireModes.FULLAUTO : fireModes.SINGLE;
    }
    else if(fireMode == fireModes.BURST) {
      fireMode = fullAuto   ? fireModes.FULLAUTO : 
                 singleFire ? fireModes.SINGLE   : fireModes.BURST;
    }
    else {
      fireMode = singleFire ? fireModes.SINGLE :
                 burstFire  ? fireModes.BURST  : fireModes.FULLAUTO;
    }
  }

  void PlaySound(AudioClip sound) {
    audioSource.PlayOneShot(sound);
  }
}