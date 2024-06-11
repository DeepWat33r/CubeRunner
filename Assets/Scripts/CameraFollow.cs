using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float playerSpeed;

    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovement>().speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
    }
}

