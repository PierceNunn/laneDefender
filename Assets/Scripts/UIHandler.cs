using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _livesDisplay;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _highScoreDisplay;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _livesDisplay.text = "Lives: " + 
            FindObjectOfType<LivesHandler>().Lives;
        _scoreDisplay.text = "Score: " + 
            FindObjectOfType<ScoreHandler>().CurrentScore;
    }
}
