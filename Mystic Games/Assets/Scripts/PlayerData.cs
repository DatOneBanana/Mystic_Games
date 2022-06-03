using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int combatHealth;
    public int mana;
    public float[] position;

    public PlayerData (Player player, CharacterCombatStatus playerStats)
    {
        health = player.currentHealth;
        mana = player.currentMana;
        combatHealth = playerStats.currHealth;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
