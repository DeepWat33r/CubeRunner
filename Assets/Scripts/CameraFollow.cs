using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; // Attach the player GameObject
    private Vector3 cameraInitialPosition;
    private float initialPlayerZ;

    void Start()
    {
        // Initialize camera and player positions
        cameraInitialPosition = transform.position;
        initialPlayerZ = player.transform.position.z;
    }

    void Update()
    {
        // Calculate the new z position based on the player's movement
        float zMovement = player.transform.position.z - initialPlayerZ;
        transform.position = new Vector3(cameraInitialPosition.x, cameraInitialPosition.y, cameraInitialPosition.z + zMovement);
    }
}

