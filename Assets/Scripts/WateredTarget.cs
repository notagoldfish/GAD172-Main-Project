using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WateredTarget : MonoBehaviour
{

    public float waterLev = 0f;
    public float maxWaterLev = 100f;
    public float fedLev = 50f;

    public UnityEvent invokeActionFed;
    public UnityEvent invokeActionUnfed;

    void Update()
    {
        if (waterLev >= fedLev)
        {
            invokeActionFed.Invoke();
        }
        if (waterLev < fedLev)
        {
            invokeActionUnfed.Invoke();
        }
    }

    public void Watered (float amount)
    {
        if (waterLev < maxWaterLev)
        {
            waterLev += amount;
        }
    }

    public void Fed ()
    {
        Debug.Log(transform.name + " is fed.");
    }

}
