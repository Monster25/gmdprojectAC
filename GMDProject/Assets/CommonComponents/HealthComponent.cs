using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    public delegate void DeathEvent(string tag);
    public static event DeathEvent deathEvent;

    public delegate void UpdateHealth(float currentHealth);
    public static event UpdateHealth updateHealth;

    //Setters Getters

    public void SetHealth(float health)
    {
        currentHealth = health;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void DealDamage(float damage)
    {
        if (currentHealth-damage<=0)
            //Death Delegate
            {
                if (deathEvent!=null)
                deathEvent(this.gameObject.tag);
                currentHealth = 0;
               
                if (this.gameObject.tag == "Player")
                {
                    updateHealth(currentHealth);
                    SceneManager.LoadScene("Scoreboard");
                    Debug.Log("Player dead");
                }
                else
                {
                    Destroy(this.gameObject);   
                }
            }
        else
        {
            Debug.Log(this+" was dealt "+damage+" damage.");
            currentHealth -= damage;

            if (this.gameObject.tag == "Player")
            {
            updateHealth(currentHealth);
            AudioSource audioData = this.gameObject.GetComponent<AudioSource>();

            audioData.Play(0);
            }
        }
    }

    public void AddHealth(float health)
    {
        Debug.Log(this+" was added "+health+" health.");
        currentHealth+=health;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (this.gameObject.tag == "Player")
            updateHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
