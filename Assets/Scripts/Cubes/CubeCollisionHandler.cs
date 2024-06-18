using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public float jumpForce = 30;
    private Collider _interactionCollider;
    private Rigidbody _cubeRigidbody;
    public event Action<GameObject, GameObject> OnCubeCollision; 
    public void Start()
    {
        CubeController cubeController = GetComponent<CubeController>();
        _cubeRigidbody = GetComponent<Rigidbody>();
        if(cubeController!= null) _interactionCollider = cubeController.interactionCollider;

    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.contacts[0].thisCollider == _interactionCollider && other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Collision Detected");
            OnCubeCollision?.Invoke(other.gameObject, this.gameObject);
        }
    }
    
}
