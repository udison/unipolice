using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
  GameHandler gameHandler;
  bool isNear = false;
  bool isFree = false;

  public GameObject pressE;
  public SpriteRenderer progressBar;
  public float time = 3f; // In seconds
  private float freeingProgress = 0f;

  public SpriteRenderer spriteRenderer;
  public Sprite[] tiedSprite;
  public Sprite[] freeSprite;
  private int spriteIndex;

  void Start()
  {
    gameHandler = GameHandler.GetGameHandler();
    spriteIndex = Random.Range(1, tiedSprite.Length);
    spriteRenderer.sprite = tiedSprite[spriteIndex];
  }

  void Update() {
    if(isNear && !isFree) {
      if(Input.GetKey(KeyCode.E)) {
        freeingProgress += Time.deltaTime;
      }
      else {
        freeingProgress -= Time.deltaTime;
      }

      Mathf.Clamp(freeingProgress, 0, time);
      freeingProgress = Mathf.Clamp01(freeingProgress);
      progressBar.size = new Vector2(freeingProgress, 1);

      if(freeingProgress == 1) {
        FreeHostage();
      }
    }
  }

  void FreeHostage() {
    isFree = true;
    gameHandler.GetComponent<Objectives>().SendMessage("UpdateQuestObjective", Objectives.QuestType.FREE_HOSTAGES);
    spriteRenderer.sprite = freeSprite[spriteIndex];

    Destroy(GetComponent<Collider2D>());
  }

  void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.layer == gameHandler.GetPlayerLayer()) {
      isNear = true;
      pressE.SetActive(true);
    }
  }

  void OnTriggerExit2D(Collider2D collider) {
    if(collider.gameObject.layer == gameHandler.GetPlayerLayer()) {
      isNear = false;
      pressE.SetActive(false);
      freeingProgress = 0f;
    }
  }
}
