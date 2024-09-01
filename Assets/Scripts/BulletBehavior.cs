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
        _bulletLifetime -= Time.deltaTime;

        if (_bulletLifetime <= 0f)
            Destroy(gameObject);
            
    }

    IEnumerator LifetimeCountdown()
    {
        for(float c = _bulletLifetime; c <= 0f; c -= Time.deltaTime)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
