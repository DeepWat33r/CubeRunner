using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public Collider interactionCollider;
    public void OnCollisionEnter(Collision other)
    {
        if(other.contacts[0].thisCollider == interactionCollider && other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Collision Detected");
            Destroy(other.gameObject);
        }
    }
}
