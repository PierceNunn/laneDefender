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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<LivesHandler>().TakeDamage();
            Destroy(gameObject);
        }
            
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
            FindObjectOfType<ScoreHandler>().CurrentScore += _pointValue;
            isMoving = false;
            enemyAnimator.Play("die");
            //destroy collider so bullets can pass through during death anim
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            //delay destroying enemy so animation can play
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
