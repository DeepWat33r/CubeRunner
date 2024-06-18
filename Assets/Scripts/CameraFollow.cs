using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float _playerSpeed;

    void Start()
    {
        _playerSpeed = player.GetComponent<PlayerMovement>().speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _playerSpeed * Time.deltaTime, Space.World);
    }
}

