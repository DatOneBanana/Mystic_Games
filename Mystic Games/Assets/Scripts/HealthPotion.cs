using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    Player playerHealth;
    HealthBar health;
    public int healthBonus = 10;

    void Awake()
    {
        playerHealth = FindObjectOfType<Player>();
        health = FindObjectOfType<HealthBar>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
            health.SetHealth(playerHealth.currentHealth);
        }
    }
}
