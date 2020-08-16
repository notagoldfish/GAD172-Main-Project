using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterGun : MonoBehaviour
{
    public float water = 1f;
    public float range = 100f;
    public float waterAmmo = 500f;
    public float fireRate = 1f;

    public Transform wGun;

    private float nextTimeToFire = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && waterAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(wGun.transform.position, wGun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            WateredTarget target = hit.transform.GetComponent<WateredTarget>();
            if (target != null)
            {
                target.Watered(water);
            }
        }
        waterAmmo -= water;
    }
}
