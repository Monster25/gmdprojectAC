using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    MyGameManager gameManager;
    private Canvas menuCanvas, optionsCanvas;

    void Awake()
    {
        MyGameManager.GetInstance().SetGameState(GameState.MAIN_MENU);
    }
    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.GetInstance().GetComponent<ScoreComponent>().StopScoring(true);
    }


    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void Options()
    {

        menuCanvas = GameObject.Find("Menu").GetComponent<Canvas>();
        optionsCanvas = GameObject.Find("Options").GetComponent<Canvas>();

        menuCanvas.enabled = false;
        optionsCanvas.enabled = true;


    }

    public void BackToMain()
    {        
        menuCanvas = GameObject.Find("Menu").GetComponent<Canvas>();
        optionsCanvas = GameObject.Find("Options").GetComponent<Canvas>();

        menuCanvas.enabled = true;
        optionsCanvas.enabled = false;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangedDropdown()
    {
        var dropdownValue = optionsCanvas.gameObject.transform.GetChild(2).GetComponent<Dropdown>().value;
        Debug.Log("Set Color to"+dropdownValue);
        gameManager.SetEnemyColor(dropdownValue);
        
    }
}
