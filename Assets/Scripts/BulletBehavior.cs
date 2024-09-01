using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifetime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + (_bulletSpeed * Time.deltaTime), 
            gameObject.transform.position.y);

        StartCoroutine(LifetimeCountdown());
            
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(true)
        {
            //add explosionnnn
            collision.gameObject.GetComponent<EnemyBehavior>().TakeDamage();
            Destroy(gameObject);
        }
    }

    IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(_bulletLifetime);
        Destroy(gameObject);
    }
}
