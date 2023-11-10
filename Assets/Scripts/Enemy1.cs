using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int currentHealth;
    public int damageToPlayer = 10;
    public float moveSpeed = 3.0f;

    private Transform player;
    public GameManager gameManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

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
        gameManager.enemyDeath1 = true;
        Destroy(gameObject);
    }
}
