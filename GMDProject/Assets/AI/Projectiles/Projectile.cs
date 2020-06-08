using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private GameObject projectileOwner;
    private float projectileSpeed;
    private Vector3 spawnPos;
    private bool startTick;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.gameObject.transform.position;
    }
    //Init
    public void Init(float damage, float projectileSpeed, GameObject owner)
    {
        this.projectileOwner = owner;
        this.damage = damage;
        this.projectileSpeed = projectileSpeed;
        startTick = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Keep Moving forward
        if (startTick)
        {
            transform.position += transform.forward * Time.deltaTime * projectileSpeed;
            
            //Destroy bullet after travelling
            if (Vector3.Distance(spawnPos, transform.position) > 35)
            Destroy(this.gameObject);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1));
            if (hit.collider != null)
            if (hit.collider.gameObject.layer == 8)
            Destroy(this.gameObject);

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("HIT OBJECT "+collision.gameObject.layer);
        //If bullet hits damageable object
        if (collision.gameObject.layer == 9 && collision.gameObject!=this.projectileOwner)
        {
            if (collision.gameObject.GetComponent<ReflectProjectiles>() != null)
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                    float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x)*Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, rot, 0);
                }
                projectileOwner = collision.gameObject;
            }
            else
            {
            var playerHealth = collision.gameObject.GetComponent<HealthComponent>();
            playerHealth.DealDamage(damage);
            Destroy(this.gameObject);
            }
        }   
        //If bullet hits wall
        else if (collision.gameObject.layer == 8)
         {
             Debug.Log("Bullet hit wall.");
             Destroy(this.gameObject);
         }
    }
}
