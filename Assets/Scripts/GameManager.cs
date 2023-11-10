using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool enemyDeath1;
    public bool enemyDeath2;
    public bool BossDeath = false;
    private bool BossSpawned = false;

    private static GameManager instance;
    public static GameManager Instance => instance;

    public int currentHealth;
    public GameObject Player;
    public GameObject BossPrefab;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (enemyDeath1 && enemyDeath2 && !BossSpawned)
        {
            SpawnBoss();
        }

        if (BossDeath)
        {
            Victory();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver");
    }

    private void Victory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void SpawnBoss()
    {
        Instantiate(BossPrefab, transform.position, Quaternion.identity);
        BossSpawned = true;
    }
}
