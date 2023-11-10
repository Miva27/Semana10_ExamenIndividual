using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject jugador;
    public GameObject balaPrefab;
    public int currentHealth;
    public float velocidadDisparo = 100f;
    public float tiempoEntreDisparos = 5.0f;

    public GameManager gameManager;

    void Start()
    {

        InvokeRepeating("DispararAlJugador", 0, tiempoEntreDisparos);
    }

    void DispararAlJugador()
    {
        if (jugador != null)
        {
            Vector3 direccion = jugador.transform.position - transform.position;
            direccion.Normalize();

            Disparar(direccion);
        }
    }

    void Disparar(Vector3 direccion)
    {

        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);


        Rigidbody rb = bala.GetComponent<Rigidbody>();


        rb.velocity = direccion * velocidadDisparo;
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
        gameManager.enemyDeath2 = true;
        Destroy(gameObject);
    }
}
