using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private Vector2 playerMovement;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.AddForce(playerMovement);
    }

    void OnMove(InputValue iValue)
    {
        Vector2 inputMovement = iValue.Get<Vector2>();
        playerMovement = new Vector3(0, inputMovement.y * _playerSpeed);
    }
}
