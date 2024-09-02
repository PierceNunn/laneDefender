using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private GameObject _explosion;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(_explosion, 
                this.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyBehavior>().TakeDamage();
            Destroy(gameObject);
        }
    }
    //destroys bullet after given time so it doesn't fly off forever
    IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(_bulletLifetime);
        Destroy(gameObject);
    }
}
