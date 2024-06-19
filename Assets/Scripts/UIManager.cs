using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateScore()
    {
        _playerScore++;
        scoreText.text = _playerScore.ToString();
    }
}
