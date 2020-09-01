using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //Falling
    float peakYPos;
    public float fallDamageThreshold = 10f;

    float prevYPos;
    float prevXPos;
    float prevZPos;

    bool fallDamage;

    public bool receivedJumpBoost = false;

    //Equipment
    public bool holdWaterGun = false;
    public bool hasWaterGun = false;
    public bool holdSeedGun = false;
    public bool hasSeedGun = false;
    public GameObject waterGun;
    public GameObject seedGun;

    public bool hasCattail;
    public bool hasSunflower;
    public bool hasLilypad;

    public int cattailAmmo = 10;
    public int sunflowerAmmo = 0;
    public int lilypadAmmo = 0;

    void Update()
    {
        //Movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Equipment

        if (hasWaterGun == true)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha1)) && holdWaterGun == false)
            {
                holdWaterGun = true;
                holdSeedGun = false;
            }
        }

        if ((holdWaterGun == false) && waterGun.activeInHierarchy == true)
        {
            waterGun.SetActive(false);
        }
        if ((holdWaterGun == true) && waterGun.activeInHierarchy == false)
        {
            waterGun.SetActive(true);
        }

        if (hasSeedGun == true)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha2)) && holdSeedGun == false)
            {
                holdSeedGun = true;
                holdWaterGun = false;
            }
        }

        if ((holdSeedGun == false) && seedGun.activeInHierarchy == true)
        {
            seedGun.SetActive(false);
        }
        if ((holdSeedGun == true) && seedGun.activeInHierarchy == false)
        {
            seedGun.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            holdWaterGun = false;
            holdSeedGun = false;
        }

        //Fall Damage
        if (isGrounded == false)
        {
            if (this.gameObject.transform.position.y > peakYPos)
            {
                peakYPos = this.gameObject.transform.position.y;
            }
        } else
        {
            if (peakYPos - fallDamageThreshold > this.gameObject.transform.position.y)
            {
                fallDamage = true;
                Respawn();
                fallDamage = false;
            }
            peakYPos = this.gameObject.transform.position.y;
        }

        //Respawning
        if (isGrounded == true && fallDamage == false)
        {
            prevYPos = this.gameObject.transform.position.y;
            prevXPos = this.gameObject.transform.position.x;
            prevZPos = this.gameObject.transform.position.z;
        }
        if (this.gameObject.transform.position.y < -100f)
        {
            Respawn();
        }

    }

    //Equipment
    public void WaterGunPickup ()
    {
        hasWaterGun = true;
    }
    public void SeedGunPickup()
    {
        hasSeedGun = true;
    }
    public void CattailSeedsPickup()
    {
        hasCattail = true;
        cattailAmmo += 100;
    }
    public void SunflowerSeedsPickup()
    {
        hasSunflower = true;
        sunflowerAmmo += 100;
    }
    public void LilypadsSeedsPickup()
    {
        hasLilypad = true;
        lilypadAmmo += 100;
    }

    void Respawn()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(prevXPos, prevYPos, prevZPos);
        Debug.Log("Falllllling");
        gameObject.SetActive(true);
    }

}
