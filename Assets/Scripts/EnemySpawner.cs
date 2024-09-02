using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject[] _enemyTypes;
    [SerializeField] private float _spawnTime;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject e = _enemyTypes[Random.Range(0, _enemyTypes.Length)];
            Vector3 spawnloc = _spawnPoints[Random.Range(0,
                _spawnPoints.Length)].transform.position;

            Instantiate(e, spawnloc, Quaternion.identity);

            yield return new WaitForSeconds(_spawnTime);
        }
        
        
        
    }
}
