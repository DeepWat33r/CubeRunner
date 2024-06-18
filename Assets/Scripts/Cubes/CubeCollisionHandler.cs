using System;
using UnityEngine;

namespace Cubes
{
    public class CubeCollisionHandler : MonoBehaviour
    {
        public float jumpForce = 30;
        private Collider _interactionCollider;
        public event Action<GameObject, GameObject> OnCubeCollision; 
        public void Start()
        {
            CubeController cubeController = GetComponent<CubeController>();
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
}
