using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform cubeSpawnPoint;
    
    // public float moveDistance = 2;
    // public float moveSpeed = 1;

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
        //StartCoroutine(MoveUpward());
        AddCube();
    }
    private void AddCube()
    {
        Debug.Log("Adding Cube");
    }

    // private IEnumerator MoveUpward()
    // {
    //     float startTime = Time.time;
    //     Vector3 startPos = transform.position;
    //     Vector3 endPos = startPos + Vector3.up * moveDistance;
    //
    //     while (Time.time < startTime + (moveDistance/ moveSpeed))
    //     {
    //         transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) * moveSpeed / moveDistance);
    //         yield return null;
    //     }
    //     
    // }
}
