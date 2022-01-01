using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoom;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Camera>().fieldOfView = 65; 
            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GetComponent<Camera>().fieldOfView = 60; 
        }
       
    }
}
