using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesHandler : MonoBehaviour
{
    [SerializeField] private int _maxLives;
    private int lives = 1;

    public int Lives { get => lives; set => lives = value; }

    void Start()
    {
        lives = _maxLives;
    }

    public void TakeDamage()
    {
        lives--;
        if (lives <= 0)
            LoseGame();
    }

    void LoseGame()
    {
        FindObjectOfType<EnemySpawner>().StopAllCoroutines();
    }
}
