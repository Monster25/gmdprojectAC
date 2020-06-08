using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

  private GameObject levelUI;

    void Awake()
    {

      
    }

    void OnEnable()
    {
        ScoreComponent.updateKilledUI += UpdateKilledUI;
        ScoreComponent.updateTimerUI += UpdateTimerUI;
        HealthComponent.updateHealth += UpdateHealthUI;
    }

    void OnDisable()
    {
      ScoreComponent.updateKilledUI -= UpdateKilledUI;
      ScoreComponent.updateTimerUI -= UpdateTimerUI;
      HealthComponent.updateHealth -= UpdateHealthUI;
    }

    void UpdateKilledUI(int nr)
    {
      if (levelUI != null)
      {
        Debug.Log("Updated kills UI" + nr);
        levelUI.transform.GetChild(0).GetComponent<Text>().text = "Enemies Killed: "+nr.ToString();
      }
    }

    void UpdateTimerUI(int nr)
    {
      if (levelUI != null)
      {
        levelUI.transform.GetChild(1).GetComponent<Text>().text = "Timer: "+nr.ToString();
      }
    }

    void UpdateHealthUI(float nr)
    {
      if (levelUI != null)
      {
        levelUI.transform.GetChild(2).GetComponent<Text>().text = "Health: "+nr.ToString();
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.GetInstance().SetGameState(GameState.LEVEL);
        Debug.Log(MyGameManager.GetInstance().GetGameState());
        MyGameManager.GetInstance().SpawnPlayer();
        levelUI = GameObject.Find("InGameUI");
        MyGameManager.GetInstance().GetComponent<ScoreComponent>().StopScoring(false);

    }

    void updateEnemiesKilled(int nr)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
