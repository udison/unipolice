using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

  public string nextLevel;
  public string rank;
  public int enemiesKilled;
  public int lostHealth;
  public int shots;
  public float accuracy;

  public bool shotWithRifle = false;
  public bool shotWithPistol = false;
  public int hits;

  void Start()
  {
    DontDestroyOnLoad(gameObject);
  }

  public string GetRank() {
    string rank = "Rank: ";
    accuracy = (hits * 100) / shots;

    // John Wick: somente pistola e 100 de hp
    if(!shotWithRifle && shotWithPistol && lostHealth == 0)
      rank += "John Wick";

    // Tony Montana: somente rifle e 100 hp
    else if(shotWithRifle && !shotWithPistol && lostHealth == 0)
      rank += "Tony Montana";

    // Rambo: disparar mais de 150 balas
    else if(shots >= 150)
      rank += "Rambo";

    // Aimbot: accuracy maior ou igual a 90
    else if(accuracy >= 90)
      rank += "Aimbot";

    // Queijo suico: < 15 hp
    else if(lostHealth >= 75)
      rank += "Queijo Suico";

    // Novato: padrao
    else
      rank += "Novato";

    return rank;
  }

  public string GetStats()
  {
    string text;
    accuracy = (hits * 100) / shots;

    // inimigos abatidos: 6
    // hp perdido: 15
    // balas disparadas: 123
    // acertos: 25%
    text = $"inimigos abatidos: {enemiesKilled}\n" +
           $"hp perdido: {lostHealth}\n" +
           $"balas disparadas: {shots}\n" +
           $"acertos: {accuracy}%";

    return text;
  }
}
