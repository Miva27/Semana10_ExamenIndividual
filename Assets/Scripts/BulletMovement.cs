using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    public float bulletLifetime = 3.0f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, bulletLifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy1 enemy1 = other.GetComponent<Enemy1>();

        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject);
        }

        Enemy2 enemy2 = other.GetComponent<Enemy2>();

        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject);
        }

        Boss boss = other.GetComponent<Boss>();

        if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

