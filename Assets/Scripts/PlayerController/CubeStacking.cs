using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacking : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform cubeSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        AddCube();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCube()
    {
        GameObject newCube = Instantiate(cubePrefab, cubeSpawnPoint.position, Quaternion.identity);
        newCube.transform.parent = this.transform;
        cubeSpawnPoint.position += new Vector3(0, newCube.transform.localScale.y, 0);
    }
}
