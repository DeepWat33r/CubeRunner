using System;
using System.Collections;
using Player;
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
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.OnFinishJump += AddCube;
            }
            UpdateCubeSubscriptions();
        }
    
        void Update()
        {
        
        }
        private void CubeToAdd(GameObject collideCube, GameObject thisCube)
        {
            Destroy(collideCube);
            TriggerUpwardMovement?.Invoke();
        }
        private void CubeToRemove(GameObject cube)
        {
            cube.transform.SetParent(null);
            StartCoroutine(DestroyCube(cube));
        }
        private void AddCube()
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, 1, transform.position.z);
            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            newCube.transform.SetParent(transform);
            UpdateCubeSubscriptions();
            Debug.Log("Cube Added");
        }
        private void UpdateCubeSubscriptions()
        {
            // Find all CubeCollisionHandlers and subscribe them to the CubeToAdd
            CubeCollisionHandler[] handlers = GetComponentsInChildren<CubeCollisionHandler>();
            foreach (CubeCollisionHandler handler in handlers)
            {
                // First unsubscribe to avoid multiple subscriptions if already subscribed
                handler.OnCubeCollision -= CubeToAdd;
                handler.OnCubeCollision += CubeToAdd;
                handler.OnWallCollision -= CubeToRemove;
                handler.OnWallCollision += CubeToRemove;
            }
        }
        IEnumerator DestroyCube(GameObject cube)
        {
            yield return new WaitForSeconds(3);
            Destroy(cube);
        }
    }
}
