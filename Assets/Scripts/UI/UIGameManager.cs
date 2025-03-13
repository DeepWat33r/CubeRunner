using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIGameManager : MonoBehaviour
    {
        public GameObject player;
        public TMP_Text scoreText;

        private int _playerScore = 0;
        // Start is called before the first frame update
        void Start()
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if(playerController!=null) playerController.ScoreUpdate += UpdateScore;
            scoreText.text = _playerScore.ToString();
        }
        private void UpdateScore()
        {
            _playerScore++;
            scoreText.text = _playerScore.ToString();
        }
    }
}
