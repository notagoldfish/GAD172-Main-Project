using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGun : MonoBehaviour
{
    public float range = 100f;
    public float fireRate = 1f;
    bool isGround;
    
    public bool equipCattail;
    public bool equipSunflower;
    public bool equipLilypad;

    public Transform sGun;

    private float nextTimeToFire = 0f;
    
    public GameObject cattailSeed;
    public GameObject sunflowerSeed;
    public GameObject lilypadSeed;

    public LayerMask groundMask;

    public PlayerController player;

    void Update()
    {
        //Shooting Cattail Seeds
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && equipCattail == true)
        {
            Debug.Log("Its getting the Input for fire");
            if (player.cattailAmmo > 0)
            {
                Debug.Log("Its getting the player's cattailAmmo input");
                nextTimeToFire = Time.time + 1f / fireRate;
                ShootCattail();
            }
        }
        //Shooting Sunflower Seeds
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && equipSunflower == true)
        {
            if (player.sunflowerAmmo > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                ShootSunflower();
            }
        }
        //Shooting Lilypad Seeds
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && equipLilypad == true)
        {
            if (player.lilypadAmmo > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                ShootLilypad();
            }
        }
        //Switching Seeds
        if ((player.hasCattail == true) && (Input.GetKey(KeyCode.Z)))
        {
            equipCattail = true;
            equipSunflower = false;
            equipLilypad = false;
        }
        if ((player.hasSunflower == true) && (Input.GetKey(KeyCode.X)))
        {
            equipCattail = false;
            equipSunflower = true;
            equipLilypad = false;
        }
        if ((player.hasLilypad == true) && (Input.GetKey(KeyCode.C)))
        {
            equipCattail = false;
            equipSunflower = false;
            equipLilypad = true;
        }
    }

    void ShootCattail()
    {
        RaycastHit hit;
        if (Physics.Raycast(sGun.transform.position, sGun.transform.forward, out hit, range))
        {
            Debug.Log("Cattail seed hit " + hit.transform.name);

            isGround = Physics.CheckSphere(hit.point, 1, groundMask);
            if (isGround == true)
            {
                Instantiate(cattailSeed, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
            }

        }
        player.cattailAmmo -= 1;
    }
    void ShootSunflower()
    {
        RaycastHit hit;
        if (Physics.Raycast(sGun.transform.position, sGun.transform.forward, out hit, range))
        {
            Debug.Log("Sunflower seed hit " + hit.transform.name);

            isGround = Physics.CheckSphere(hit.point, 1, groundMask);
            if (isGround == true)
            {
                Instantiate(sunflowerSeed, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
            }

        }
        player.sunflowerAmmo -= 1;
    }
    void ShootLilypad()
    {
        RaycastHit hit;
        if (Physics.Raycast(sGun.transform.position, sGun.transform.forward, out hit, range))
        {
            Debug.Log("Lilypad seed hit " + hit.transform.name);

            isGround = Physics.CheckSphere(hit.point, 1, groundMask);
            if (isGround == true)
            {
                Instantiate(lilypadSeed, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
            }

        }
        player.lilypadAmmo -= 1;
    }
}
