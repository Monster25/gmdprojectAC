//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public enum GameState {MAIN_MENU, LEVEL, SCOREBOARD}

public delegate void OnStateChangeHandler();
public class MyGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private Transform playerTransform;
    //public event OnStateChangeHandler OnStateChange;


    private int enemyMaterialId;
    public int GetEnemyMaterialId()
    {
        return enemyMaterialId;
    }

    public void SetEnemyColor(int value)
    {
        enemyMaterialId = value;
        Debug.Log("Changed to: "+value);
    }

    public GameState gameState {get; private set;}
    private static MyGameManager instance;

    public void SetGameState(GameState state)
    {
        this.gameState = state;
      //  OnStateChange();
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

    public static MyGameManager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
       playerTransform = Instantiate(playerPrefab, GameObject.Find("PlayerSpawner").transform.position, Quaternion.identity).transform;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
