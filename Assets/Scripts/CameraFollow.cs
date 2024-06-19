using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Transform playerModel;
    private float _playerSpeed;

    void Start()
    {
        _playerSpeed = player.GetComponent<PlayerMovement>().speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _playerSpeed * Time.deltaTime, Space.World);
        Vector3 playerModelPosition = player.transform.TransformPoint(playerModel.localPosition);

        if (playerModelPosition.y > 9.8)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = playerModelPosition.y;
            transform.position = newPosition;
        }
    }
}

