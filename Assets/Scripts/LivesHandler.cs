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
        Lives = _maxLives;
    }

    public void TakeDamage()
    {
        Lives--;
        if (Lives <= 0)
            ;
    }
}
