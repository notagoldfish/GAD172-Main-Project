using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour
{

    public GameObject player;
    bool onLilypad = false;
    public float jumpBoost = 40f;
    public float noFallDamage = 100f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        WaterPlantGrowth waterPlantGrowth = this.transform.gameObject.GetComponent<WaterPlantGrowth>();
        if (waterPlantGrowth != null && waterPlantGrowth.fed == true && playerController != null)
        {
            if (onLilypad == true && playerController.receivedJumpBoost == false)
            {
                playerController.jumpHeight += jumpBoost;
                playerController.fallDamageThreshold += noFallDamage;
                playerController.receivedJumpBoost = true;
            }
            if (onLilypad == false && playerController.receivedJumpBoost == true)
            {
                playerController.jumpHeight -= jumpBoost;
                playerController.fallDamageThreshold -= noFallDamage;
                playerController.receivedJumpBoost = false;
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        onLilypad = true;
    }
    private void OnTriggerExit(Collider player)
    {
        onLilypad = false;
    }
}
