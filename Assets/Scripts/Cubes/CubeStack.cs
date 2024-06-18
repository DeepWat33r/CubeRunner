using System;
using UnityEngine;

namespace Cubes
{
    public class CubeStack : MonoBehaviour
    {
        public GameObject cubePrefab;
        public Transform cubeSpawnPoint;
        public event Action TriggerUpwardMovement;  // Event to trigger upward movement
    

        void Start()
        {
            CubeCollisionHandler[] handlers = GetComponentsInChildren<CubeCollisionHandler>();
            foreach (CubeCollisionHandler handler in handlers)
            {
                handler.OnCubeCollision += CubeToAdd;
            }
        }
    
        void Update()
        {
        
        }
        private void CubeToAdd(GameObject collideCube, GameObject thisCube)
        {
            Destroy(collideCube);
            TriggerUpwardMovement?.Invoke();
            AddCube();
        }
        private void AddCube()
        {
            Debug.Log("Adding Cube");
        }
    }
}
