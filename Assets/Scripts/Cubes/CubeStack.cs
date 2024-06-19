using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Cubes
{
    public class CubeStack : MonoBehaviour
    {
        public GameObject cubePrefab;
        public event Action TriggerUpwardMovement;  // Event to trigger upward movement
        public event Action ScoreUpdate;  // Event to update score

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
            ScoreUpdate?.Invoke();
        }
        private void CubeToRemove(GameObject cube)
        {
            cube.transform.SetParent(null);
            AllignCubes();
            StartCoroutine(DestroyCube(cube));
        }
        private void AddCube()
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, 1, transform.position.z);
            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            newCube.transform.SetParent(transform);
            UpdateCubeSubscriptions();
            AllignCubes();
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

        private void AllignCubes()
        {
            foreach (Transform child in transform)
            {
                Vector3 allignedPosition = new Vector3(transform.position.x, child.position.y, transform.position.z);
                child.position = allignedPosition;
            }
        }
        IEnumerator DestroyCube(GameObject cube)
        {
            yield return new WaitForSeconds(3);
            Destroy(cube);
        }
    }
}
