using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _livesDisplay;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _highScoreDisplay;

    void Update()
    {
        _livesDisplay.text = "Lives: " + 
            FindObjectOfType<LivesHandler>().Lives;
        _scoreDisplay.text = "Score: " + 
            FindObjectOfType<ScoreHandler>().CurrentScore;
        _highScoreDisplay.text = "High Score: " +
            ScoreHandler.HighScore;
    }
}
