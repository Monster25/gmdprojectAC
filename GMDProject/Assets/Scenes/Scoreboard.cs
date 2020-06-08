using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{

    MyGameManager gameManager;
    GameObject scoreboardUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        scoreboardUI = GameObject.Find("ScoreboardUI");
        scoreboardUI.transform.GetChild(1).GetComponent<Text>().text = "Enemies Killed: "+MyGameManager.GetInstance().GetComponent<ScoreComponent>().GetEnemiesKilled();

        scoreboardUI.transform.GetChild(2).GetComponent<Text>().text = "Timer: "+(int)MyGameManager.GetInstance().GetComponent<ScoreComponent>().GetTimer()%60;
    }

    void Awake()
    {
        MyGameManager.GetInstance().SetGameState(GameState.SCOREBOARD);
        MyGameManager.GetInstance().GetComponent<ScoreComponent>().StopScoring(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        MyGameManager.GetInstance().GetComponent<ScoreComponent>().ResetVars();
        SceneManager.LoadScene("MainMenu");
    }


}
