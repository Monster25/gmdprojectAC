using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float damage = 1;
    [SerializeField]
    private float cooldown = 5;
    [SerializeField]
    private float bulletSpeed = 1;
    private float actualCD;
    private bool bCanFire = true;

    // Start is called before the first frame update
    void Start()
    {
        actualCD = cooldown;
    }

    void Fire()
    {
            AudioSource audioData = this.gameObject.GetComponent<AudioSource>();
            audioData.Play(0);
            bCanFire = false;
            //Instantiate bullet etc give it stuff;
            Quaternion spawnRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
            //Quaternion spawnRotation = Quaternion.Euler(transform.eulerAngles);
            var bullet = Instantiate(projectilePrefab, transform.position+transform.forward   , transform.rotation);
            var bulletComponent = bullet.GetComponent<Projectile>();
            bulletComponent.Init(damage, bulletSpeed, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward,out hit, 4000);
        if (hit.collider.gameObject.layer == 8)
        {

        }
        else if (bCanFire)
        {
            bCanFire = false;
            Fire();
            actualCD = cooldown;
        }
        else
        {
            actualCD -= Time.deltaTime;
            if (actualCD <= 0)
            {
                bCanFire = true;
            }
        }
    }

}
