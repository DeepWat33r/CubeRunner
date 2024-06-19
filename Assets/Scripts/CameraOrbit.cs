using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Target to orbit around
    public float distance = 5.0f; // Distance from the target
    public float rotationSpeed = 50.0f; // Speed of rotation around the target
    public float tiltAngle = 30.0f; // Angle to tilt the camera downward
    public float initialAngle; // Initial angle for the camera position around the target

    void Start()
    {
        if (target != null)
        {
            // Set the initial position of the camera
            UpdateCameraPosition(initialAngle);
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Incrementally update the camera's rotation
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

