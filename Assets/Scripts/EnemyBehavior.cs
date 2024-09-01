using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private int _pointValue;
    [SerializeField] private float _timeToPauseOnHit;
    private bool isMoving = true;

    
    void Update()
    {
        if (isMoving)
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x - (_enemySpeed * 
                Time.deltaTime), gameObject.transform.position.y);
    }

    public void TakeDamage()
    {
        _enemyHealth--;
        StopAllCoroutines();
        StartCoroutine(DamagePause());

        if (_enemyHealth <= 0)
            Destroy(gameObject);
    }

    IEnumerator DamagePause()
    {
        isMoving = false;
        yield return new WaitForSeconds(_timeToPauseOnHit);
        isMoving = true;
    }


}
