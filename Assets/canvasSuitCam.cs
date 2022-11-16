using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasSuitCam : MonoBehaviour
{
    public GameObject cam;
    public float distance;

  
    void Update()
    {
        Vector3 laPosition = cam.transform.position + cam.transform.forward * distance;
        laPosition.y = 1f;
        transform.position = laPosition;

        Quaternion laRotation = cam.transform.rotation;
        laRotation.x = 0f;
        laRotation.z = 0f;
        transform.rotation = laRotation;

    }
}
