using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private int _pointValue;
    [SerializeField] private float _timeToPauseOnHit;
    private Animator enemyAnimator;
    private bool isMoving = true;

    private void Start()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
    }
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
        if(_enemyHealth > 0)
        {
            enemyAnimator.Play("hurt");
            StopAllCoroutines();
            StartCoroutine(DamagePause());
        }
        else
        {
            isMoving = false;
            enemyAnimator.Play("die");
            Invoke("DestroySelf", 1f);
        }
            
    }

    //DestroySelf's just needed due to Invoke not taking in variables for its
    //function
    void DestroySelf()
    {
        Destroy(gameObject);
    }

    IEnumerator DamagePause()
    {
        isMoving = false;
        yield return new WaitForSeconds(_timeToPauseOnHit);
        isMoving = true;
    }


}
