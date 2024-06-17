using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Collider interactionCollider;
    // Start is called before the first frame update
    void Start()
    {
        interactionCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.parent != null && transform.parent.parent.CompareTag("Player"))
        {
            interactionCollider.enabled = true;
        }
        else
        {
            interactionCollider.enabled = false;
        }
    }
}
