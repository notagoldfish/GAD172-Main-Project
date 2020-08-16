using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{

    bool fed = false;

    void Start()
    {
        Debug.Log("Parent of Seedling is " + this.transform.parent.gameObject);
    }
    
    void Update()
    {
        WateredTarget targetScript = this.transform.parent.gameObject.GetComponent<WateredTarget>();
        if (targetScript != null)
        {
            if ((targetScript.waterLev >= 5) && (fed == false))
            {
                Debug.Log("This " + this.transform.parent.gameObject + "has a water level of 5 or more :)");
                targetScript.waterLev -= 5;
                fed = true;
            }
        }
        if (fed == true)
        {
            Grow();
        }
        PlantGrowth plantScript = this.transform.parent.gameObject.GetComponent<PlantGrowth>();
        if (plantScript != null)
        {
            Destroy(gameObject);
            Debug.Log("Nahanah");
        }
        
    }

    public void Grow() 
    {
        Animator anim = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        anim.SetTrigger("Grow");
    }
    public void Die() 
    {
        Animator anim = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        anim.SetTrigger("Die");
    }
}
