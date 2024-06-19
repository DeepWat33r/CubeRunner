using System;
using UnityEngine;

namespace Cubes
{
    public class CubeCollisionHandler : MonoBehaviour
    {
        private Collider _interactionCollider;
        public event Action<GameObject, GameObject> OnCubeCollision;
        public event Action<GameObject> OnWallCollision; 
        public void Start()
        {
            CubeController cubeController = GetComponent<CubeController>();
            if(cubeController!= null) _interactionCollider = cubeController.interactionCollider;

        }
        public void OnCollisionEnter(Collision other)
        {
            if(other.contacts[0].thisCollider == _interactionCollider && other.gameObject.CompareTag("Cube"))
            {
                Debug.Log("Collision Detected with Cube");
                OnCubeCollision?.Invoke(other.gameObject, gameObject);
            }
            if(other.contacts[0].thisCollider == _interactionCollider && other.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Collision Detected with Wall");
                OnWallCollision?.Invoke(gameObject);
            }
        }
    
    }
}
