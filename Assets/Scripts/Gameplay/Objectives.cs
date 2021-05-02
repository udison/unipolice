using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
  public GameObject questContainer;
  public GameObject questPrefab;

  public enum QuestType {
    KILL_ENEMIES,
    FREE_HOSTAGES,
    DEFUSE_BOMB,
    PICKUP_ITEM,
    DO_ACTION
  }

  [System.Serializable]
  public struct Quest {
    public bool isCompleted;
    public string title;
    public QuestType type;
    public float counter;
    public float quantity;
    public GameObject uiObj;

    public void UpdateCounter() {

      // Update the objective counter text
      string newCounter = (counter <= quantity) ? counter.ToString() : quantity.ToString();
      Text text = uiObj.transform.Find("Counter").GetComponent<Text>();
      text.text = $"{newCounter}/{quantity}";

      // If quest is completed
      if(counter >= quantity) {
        isCompleted = true;
        text.color = new Color32(175, 255, 0, 255);
        uiObj.transform.Find("CompletionCircle").Find("Check").gameObject.SetActive(true);
      }
    }
  }

  public Quest[] quests;
  
  void Start() {
    for(int i = 0; i < quests.Length; i++) {

      // Instantiate the quest ui
      GameObject questObj = Instantiate(questPrefab, questContainer.transform);

      // Get ui title, counter and rect transform
      Text title = questObj.transform.Find("Title").GetComponent<Text>();
      Text counter = questObj.transform.Find("Counter").GetComponent<Text>();
      RectTransform rectTransform = questObj.GetComponent<RectTransform>();

      // Set quest object name, text and counter
      questObj.name += "_" + i;
      title.text = quests[i].title;
      counter.text = $"0/{quests[i].quantity}";
      
      // Set the quest obj position
      rectTransform.pivot = Vector2.one;
      Vector2 newPos = new Vector2(0, (rectTransform.rect.height + 10) * -i);
      rectTransform.anchoredPosition = newPos;

      // Saves the object in the array
      quests[i].uiObj = questObj;
    }
  }

  void UpdateQuestObjective(QuestType type) {
    switch(type) {
      case QuestType.KILL_ENEMIES:
        for(int i = 0; i < quests.Length; i++) {
          if(quests[i].type == type) {
            quests[i].counter++;
            quests[i].UpdateCounter();
          }
        }
      break;
    }
  }
}
