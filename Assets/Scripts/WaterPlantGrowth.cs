using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlantGrowth : MonoBehaviour
{

    public bool fed = false;

    void Start()
    {
        Debug.Log("Parent of Water Seed is " + this.transform.parent.gameObject);
    }

    void Update()
    {
        StillWater targetScript = this.transform.parent.gameObject.GetComponent<StillWater>();
        if (targetScript != null)
        {
            fed = true;
        }
        if (fed == true)
        {
            Grow();
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
