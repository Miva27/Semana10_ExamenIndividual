using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int Health;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.currentHealth = Health;
        }
        else
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    void Update()
    {

    }
}
