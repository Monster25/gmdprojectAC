using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManagerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GameManagerPrefab, new Vector3(0,0,0), Quaternion.identity);
        Invoke("LoadLevel", 0.1f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
