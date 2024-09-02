using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    void Start()
    {
        Invoke("DestroySelf", _lifeTime);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
