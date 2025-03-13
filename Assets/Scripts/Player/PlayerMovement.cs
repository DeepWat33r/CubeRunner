using System;
using Cubes;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f; 
        [SerializeField]private int maxSideMovingCount = 2;
        [SerializeField] private float sideMovingDistance = 2.0f; 
        [SerializeField] private float sideMovingSpeed = 2.0f; 
        [SerializeField] private float upwardMoveDistance = 3f; 
        [SerializeField] private float upwardMoveSpeed = 10f;
        private float _sideMoveInput; 
        private float _sideTargetPositionX; 
        private bool _isMovingUpward; 
        private float _initialY; 

        public event Action OnFinishJump;
        void Start()
        {
            CubeStack cubeStack = GetComponent<CubeStack>();
            if (cubeStack != null)
            {
                cubeStack.TriggerUpwardMovement += TriggerUpwardMove;
            }
            _sideTargetPositionX = transform.position.x;
            _initialY = transform.position.y;
        }

        void Update()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime), Space.World);

            if (Input.GetKeyDown(KeyCode.A))
            {
                _sideMoveInput = -1; // Move left
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _sideMoveInput = 1; 
            }

            if (_sideMoveInput != 0)
            {
                float newTargetX = transform.position.x + _sideMoveInput * sideMovingDistance;
                _sideTargetPositionX = Mathf.Clamp(newTargetX, -maxSideMovingCount * sideMovingDistance, maxSideMovingCount * sideMovingDistance);
                _sideMoveInput = 0; 
            }
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(_sideTargetPositionX, currentPosition.y, currentPosition.z);
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, sideMovingSpeed * Time.deltaTime);

            if (_isMovingUpward)
            {
                Vector3 upwardPosition = new Vector3(transform.position.x, _initialY + upwardMoveDistance, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, upwardPosition, upwardMoveSpeed * Time.deltaTime);

                if (Mathf.Abs(transform.position.y - (_initialY + upwardMoveDistance)) < 0.01f)
                {
                    _isMovingUpward = false;
                    OnFinishJump?.Invoke();
                }
            }
        }

        private void TriggerUpwardMove()
        {
            _isMovingUpward = true; 
            _initialY = transform.position.y; 
        }
    }
}
