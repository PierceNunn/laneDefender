using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private int _enemyHealth;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x - (_enemySpeed * Time.deltaTime),
            gameObject.transform.position.y);
    }

    public void TakeDamage()
    {
        _enemyHealth--;
        if (_enemyHealth <= 0)
            Destroy(gameObject);
    }


}
