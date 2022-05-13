using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    Player playerMana;
    ManaBar mana;
    public int manaBonus = 5;

    void Awake()
    {
        playerMana = FindObjectOfType<Player>();
        mana = FindObjectOfType<ManaBar>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerMana.currentMana < playerMana.maxMana)
        {
            Destroy(gameObject);
            playerMana.currentMana = playerMana.currentMana + manaBonus;
            mana.SetMana(playerMana.currentMana);
        }
    }
}
