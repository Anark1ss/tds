using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public AudioSource akSound;
    public AudioSource shotgunSound;

    public int weaponIndex;
    public float bulletForce = 40f;
    private float fireTimer;
    public float fireDelay;

    void Start()
    {
        weaponIndex = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().weaponIndex;
    }

    void Update()
    {
        WeaponSwitch();
        FireDelay();
    }

    private void FireDelay()
    {
        if ((fireTimer += Time.deltaTime) > fireDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                fireTimer = 0.0f;
                switch (weaponIndex)
                {
                    case 0:
                        ShootAk();
                        break;
                    case 1:
                        ShootShootgun();
                        break;
                    default:
                        break;
                }
               
            }
        }
    }

    private void WeaponSwitch()
    {
        weaponIndex = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().weaponIndex;
        switch (weaponIndex)
        {
            case 0:
                fireDelay = 0.1f;
                break;
            case 1:
                fireDelay = 0.5f;
                break;
            default:
                break;
        }
    }
    void ShootAk()//generate bulet
    {     
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
        akSound.Play();
    }

    void ShootShootgun()//generate bulet
    {
        for(float i = -30f; i < 30f; )
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.Euler(0, bullet.transform.rotation.z + i, 0); 
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
            i += 15f;
        }
        shotgunSound.Play();
    }


}
