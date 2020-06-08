using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    private int enemiesKilled = 0;
    private float timer = 0.0f;

    private bool stopScoring = true;
    public delegate void UpdateKilledUI(int nr);
    public static event UpdateKilledUI updateKilledUI;
    public delegate void UpdateTimerUI(int nr);
    public static event UpdateTimerUI updateTimerUI;

    void OnEnable()
    {
        HealthComponent.deathEvent += KilledEnemy;
    }

    void OnDisable()
    {
        HealthComponent.deathEvent -= KilledEnemy;
    }

    void KilledEnemy(string tag)
    {
        if (tag == "Player" || tag == "Pressure")
        {

        }
        else
        {
            enemiesKilled++;
            if (updateKilledUI!=null)
            {
            updateKilledUI(enemiesKilled);
            Debug.Log("Enemies killed: "+enemiesKilled);
            }
            
        }
    }
    public void StopScoring(bool value)
    {
        stopScoring = value;
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }
    public float GetTimer()
    {
        return timer;
    }

    public void ResetVars()
    {
        enemiesKilled = 0;
        timer = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
            //Initial Update
            if (updateKilledUI!=null)
            updateKilledUI(enemiesKilled);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopScoring)
        {

        }
        else
        {
            timer+=Time.deltaTime;
            if (updateTimerUI!=null)
            updateTimerUI((int)timer%60);
        }

    }
}
