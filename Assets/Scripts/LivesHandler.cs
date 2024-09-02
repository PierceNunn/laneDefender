using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesHandler : MonoBehaviour
{
    [SerializeField] private int _maxLives;
    [SerializeField] private AudioSource _loseLifeSFX;
    [SerializeField] private Canvas _gameOverUI;
    private int lives = 1;

    public int Lives { get => lives; set => lives = value; }

    void Start()
    {
        lives = _maxLives;
    }

    public void TakeDamage()
    {
        _loseLifeSFX.Play();
        lives--;
        if (lives <= 0)
            LoseGame();
    }

    void LoseGame()
    {
        FindObjectOfType<EnemySpawner>().StopAllCoroutines();
        FindObjectOfType<ScoreHandler>().SetHighScore();
        _gameOverUI.gameObject.SetActive(true);
    }
}
