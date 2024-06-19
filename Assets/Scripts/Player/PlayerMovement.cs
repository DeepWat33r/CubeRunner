using System;
using Cubes;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f; // Forward movement speed
        [SerializeField]private int maxSideMovingCount = 2;
        [SerializeField] private float sideMovingDistance = 2.0f; // Maximum side movement distance
        [SerializeField] private float sideMovingSpeed = 2.0f; // Speed of side movement
        [SerializeField] private float upwardMoveDistance = 3f; // Height of upward movement
        [SerializeField] private float upwardMoveSpeed = 10f;
        private float _sideMoveInput; // Input for side movement
        private float _sideTargetPositionX; // Target X position for side movement
        private bool _isMovingUpward; // Flag for upward movement
        private float _initialY; // Initial Y position for upward movement

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
            // Handle forward movement
            transform.Translate(Vector3.forward * (speed * Time.deltaTime), Space.World);

            // Handle side movement input
            if (Input.GetKeyDown(KeyCode.A))
            {
                _sideMoveInput = -1; // Move left
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _sideMoveInput = 1; // Move right
            }

            // Update side target position based on input
            if (_sideMoveInput != 0)
            {
                float newTargetX = transform.position.x + _sideMoveInput * sideMovingDistance;
                _sideTargetPositionX = Mathf.Clamp(newTargetX, -maxSideMovingCount * sideMovingDistance, maxSideMovingCount * sideMovingDistance);
                _sideMoveInput = 0; // Reset input
            }
            // Smoothly move to the target side position
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(_sideTargetPositionX, currentPosition.y, currentPosition.z);
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, sideMovingSpeed * Time.deltaTime);

            // Handle upward movement
            if (_isMovingUpward)
            {
                Vector3 upwardPosition = new Vector3(transform.position.x, _initialY + upwardMoveDistance, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, upwardPosition, upwardMoveSpeed * Time.deltaTime);

                // Check if reached the target height
                if (Mathf.Abs(transform.position.y - (_initialY + upwardMoveDistance)) < 0.01f)
                {
                    _isMovingUpward = false; // Stop upward movement
                    OnFinishJump?.Invoke();
                }
            }
        }

        private void TriggerUpwardMove()
        {
            _isMovingUpward = true; // Start upward movement
            _initialY = transform.position.y; // Reset initial Y
        }
    }
}
