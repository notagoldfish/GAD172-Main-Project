using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteraction : MonoBehaviour
{
    public GameObject displayText;
    public void DisplayText ()
    {
        if (displayText.activeInHierarchy == false)
        {
            displayText.SetActive(true);
        } else
        {
            displayText.SetActive(false);
        }
    }
}
