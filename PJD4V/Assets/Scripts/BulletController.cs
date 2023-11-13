using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float moveSpeed;

    public int damage;
    
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private GameObject bulletExplosion;
    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject,2f);
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        _rigidbody2D.velocity = transform.localScale.x * transform.right * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IDamageable>().TakeEnergy(damage);
            Instantiate(bulletExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Instantiate(bulletExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
