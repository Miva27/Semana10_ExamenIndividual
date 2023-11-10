using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int currentHealth;
    public int damageToPlayer = 10;
    public float moveSpeed = 3.0f;
    public float ShootVelocity = 5.0f;
    public float timeBetweenShots = 5.0f;
    public GameObject Bullet;
    public GameObject Player;

    private Transform player;
    public GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindWithTag("Player").transform;
        Player = GameObject.FindWithTag("Player");
        InvokeRepeating("DispararAlPlayer", 0, timeBetweenShots);
    }

    void Update()
    {

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.Translate(direction * moveSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < 1.0f)
            {

                if (gameManager != null)
                {
                    gameManager.TakeDamage(damageToPlayer);
                }
            }
        }
    }

    void DispararAlPlayer()
    {
        if (Player != null)
        {
            Vector3 direccion = Player.transform.position - transform.position;
            direccion.Normalize();

            Disparar(direccion);
        }
    }

    void Disparar(Vector3 direccion)
    {

        GameObject bala = Instantiate(Bullet, transform.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = direccion * ShootVelocity;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameManager.BossDeath = true;
        Destroy(gameObject);
    }
}
