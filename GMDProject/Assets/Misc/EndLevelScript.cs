using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MyGameManager.GetInstance().GetComponent<ScoreComponent>().StopScoring(false);
            LoadScoreboard();
        }
    }

    void LoadScoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
