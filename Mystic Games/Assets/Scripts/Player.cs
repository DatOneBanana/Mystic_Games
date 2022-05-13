using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICustomerShop
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int currency = 0;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentHealth != 0)
        {
            TakeDamage(20);
            Debug.Log(currentHealth);
        }
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item" + itemType);
    }

}
