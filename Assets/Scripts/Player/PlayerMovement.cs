using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    //public float speed { get; private set; } = 5.0f;
    [SerializeField] public float speed = 5.0f;
    [SerializeField] private float sideMovingDistance = 2.0f;
    [SerializeField] private float sideMovingSpeed = 2.0f;
    private int _maxSideMovingCount = 2;
    private int _currentSideMovingCount = 0;
    private bool isMovingSideways = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (!isMovingSideways)
        {
            if (Input.GetKeyDown(KeyCode.A) && _currentSideMovingCount > -_maxSideMovingCount)
            {
                StartCoroutine(SideMove(Vector3.left));
                _currentSideMovingCount--;
            }
            else if (Input.GetKeyDown(KeyCode.D) && _currentSideMovingCount < _maxSideMovingCount)
            {
                StartCoroutine(SideMove(Vector3.right));
                _currentSideMovingCount++;
            }
        }
    }
    IEnumerator SideMove(Vector3 direction)
    {
        isMovingSideways = true;
        float startTime = Time.time;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction * sideMovingDistance;

        while (Time.time < startTime + 1f / sideMovingSpeed)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) * sideMovingSpeed) + Vector3.forward * speed * (Time.time - startTime);
            yield return null;
        }

        isMovingSideways = false;
    }
}
