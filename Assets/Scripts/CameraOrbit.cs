using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; 
    public float distance = 5.0f; 
    public float rotationSpeed = 50.0f; 
    public float tiltAngle = 30.0f; 
    public float initialAngle; 

    void Start()
    {
        if (target != null)
        {
            UpdateCameraPosition(initialAngle);
        }
    }

    void Update()
    {
        if (target != null)
        {
            initialAngle += rotationSpeed * Time.deltaTime;
            UpdateCameraPosition(initialAngle);
        }
    }

    private void UpdateCameraPosition(float angle)
    {
        Quaternion rotation = Quaternion.Euler(tiltAngle, angle, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

        transform.position = position;
        transform.LookAt(target);
    }
}

