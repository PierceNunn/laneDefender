using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _shootCooldown;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _barrel;

    private bool canShoot = true;
    private Vector2 playerMovement;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        rb.AddForce(playerMovement);
    }

    void OnMove(InputValue iValue)
    {
        Vector2 inputMovement = iValue.Get<Vector2>();
        playerMovement = new Vector2(0, inputMovement.y * _playerSpeed);
    }

    void OnRestart()
    {
        FindObjectOfType<SceneLoader>().LoadScene("SampleScene");
    }

    void OnFire()
    {
        if(canShoot)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(_bullet, 
                _barrel.transform.position, Quaternion.identity);
            Instantiate(_explosion, 
                _barrel.transform.position, Quaternion.identity);
            canShoot = false;
            StartCoroutine(ShootCooldown());
        }
        
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(_shootCooldown);
        canShoot = true;
    }
}
