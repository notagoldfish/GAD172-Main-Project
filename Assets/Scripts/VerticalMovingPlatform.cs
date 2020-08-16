using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    public Vector3[] points; 
    public int pointTarget = 0; 
    private Vector3 currentTarget; 
    public float tolerance; 
    public float speed; 
    public float delayTime; 
    private float delayStart; 
    public bool automatic; 

    private void Start()
    {
        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform(); 
        }
        else
        {
            UpdateTarget(); 
        }
    }


    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance) 
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic) 
        {
            if (Time.time - delayStart > delayTime) 
            {
                NextPlatform(); 
            }
        }
    }
    public void NextPlatform()
    {
        pointTarget++; 
        if (pointTarget >= points.Length) 
        {
            pointTarget = 0;
        }
        currentTarget = points[pointTarget]; 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
    
    public void Automatic()
    {
        automatic = true;
    }

    public void PointOne()
    {
        currentTarget = points[0];
    }
    public void PointTwo()
    {
        currentTarget = points[1];
    }
}
