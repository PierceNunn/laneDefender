using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private int _currentScore;
    private static int highScore;

    public int CurrentScore { get => _currentScore; set => _currentScore = value; }
    public static int HighScore { get => highScore; set => highScore = value; }

    public void SetHighScore()
    {
        if (_currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
            
        
    }
}
