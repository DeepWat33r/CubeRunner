using System;
using Cubes;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public int score;
        public event Action ScoreUpdate;
        void Start()
        {
            score = 0;
            CubeStack cubeStack = GetComponent<CubeStack>();
            if (cubeStack != null)
            {
                cubeStack.ScoreUpdate += UpdateScore;
            }
        }

        void Update()
        {
        
        }
        private void UpdateScore()
        {
            score++;
            ScoreUpdate?.Invoke();
            Debug.Log("Score Updated: " + score);
        }
    }
}
