using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject seedGun;

    public GameObject waterGunIcon;
    public GameObject seedGunIcon;
    public GameObject cattailSeedsIcon;
    public GameObject sunflowerSeedsIcon;
    public GameObject lilypadSeedsIcon;

    public GameObject waterGunSelect;
    public GameObject seedGunSelect;
    public GameObject cattailSelect;
    public GameObject sunflowerSelect;
    public GameObject lilypadSelect;

    void Update()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //Put in UI
            //Water Gun
            if (playerController.hasWaterGun == true)
            {
                waterGunIcon.SetActive(true);
            }
            else
            {
                waterGunIcon.SetActive(false);
            }
            //Seed Gun
            if (playerController.hasSeedGun == true)
            {
                seedGunIcon.SetActive(true);
            }
            else
            {
                seedGunIcon.SetActive(false);
            }
            //Cattails
            if (playerController.hasCattail == true)
            {
                cattailSeedsIcon.SetActive(true);
            }
            else
            {
                cattailSeedsIcon.SetActive(false);
            }
            //Sunflowers
            if (playerController.hasSunflower == true)
            {
                sunflowerSeedsIcon.SetActive(true);
            }
            else
            {
                sunflowerSeedsIcon.SetActive(false);
            }
            //Lilypads
            if (playerController.hasLilypad == true)
            {
                lilypadSeedsIcon.SetActive(true);
            }
            else
            {
                lilypadSeedsIcon.SetActive(false);
            }
            //Select in UI
            //Water Gun
            if (playerController.holdWaterGun == false)
            {
                waterGunSelect.SetActive(true);
            }
            else
            {
                waterGunSelect.SetActive(false);
            }
            //Seed Gun
            if (playerController.holdSeedGun == false)
            {
                seedGunSelect.SetActive(true);
            }
            else
            {
                seedGunSelect.SetActive(false);
            }
        }
        SeedGun seedGunScript = seedGun.GetComponent<SeedGun>();
        if (seedGunScript != null)
        {
            //Select in UI
            //Cattails
            if (seedGunScript.equipCattail == false)
            {
                cattailSelect.SetActive(true);
            }
            else
            {
                cattailSelect.SetActive(false);
            }
            //Sunflowers
            if (seedGunScript.equipSunflower == false)
            {
                sunflowerSelect.SetActive(true);
            }
            else
            {
                sunflowerSelect.SetActive(false);
            }
            //Lilypads
            if (seedGunScript.equipLilypad == false)
            {
                lilypadSelect.SetActive(true);
            }
            else
            {
                lilypadSelect.SetActive(false);
            }
        }
    }
}
