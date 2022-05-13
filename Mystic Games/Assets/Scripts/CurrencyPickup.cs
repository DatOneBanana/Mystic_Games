using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    Player playerCurrency;
    public int worth = 100;

    void Awake()
    {
        playerCurrency = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        //playerCurrency.IncreaseCurrency(worth);
    }
}
