using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {Water, Fire, Earth, Wood, Metal, None}

public class CharacterCombatStatus : MonoBehaviour 
{
    public string charName = "name";

    public Weapons.ItemType weapon;
    public int damage;

    public int maxHealth;
    public int currHealth;

    public int maxMana;
    public int currMana;

    public Type type;

    public int missChance;

    public bool TakeDamage(int dmg, Type attackingType)
    {
        int damage = (int)(Random.Range(0.75f, 1.25f) * dmg);
        if(TypeAdvantage(attackingType)) {
            damage *= 2;
            currHealth -= damage;
            if (currHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(TypeDisadvantage(attackingType)) {
            damage /= 2;
            currHealth -= damage;
            if (currHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        currHealth -= damage;
        if (currHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Heals 25% hp
    public void Heal()
    {
        int healthToHeal = maxHealth / 4;
        currHealth += healthToHeal;
        if(currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    //Checks to see if the attacker has advantage (double damage)
    public bool TypeAdvantage(Type attackingType) {
        if((attackingType == Type.Fire) && (this.type == Type.Metal)) {
            return true;
        }
        else if((attackingType == Type.Metal) && (this.type == Type.Wood)) {
            return true;
        }
        else if((attackingType == Type.Wood) && (this.type == Type.Earth)) {
            return true;
        }
        else if((attackingType == Type.Earth) && (this.type == Type.Water)) {
            return true;
        }
        else if((attackingType == Type.Water) && (this.type == Type.Fire)) {
            return true;
        }
        return false;
    }

    //Checks to see if the attacker has disadvantage (half damage)
    public bool TypeDisadvantage(Type attackingType) {
        if((attackingType == Type.Metal) && (this.type == Type.Fire)) {
            return true;
        }
        else if((attackingType == Type.Wood) && (this.type == Type.Metal)) {
            return true;
        }
        else if((attackingType == Type.Earth) && (this.type == Type.Wood)) {
            return true;
        }
        else if((attackingType == Type.Water) && (this.type == Type.Earth)) {
            return true;
        }
        else if((attackingType == Type.Fire) && (this.type == Type.Water)) {
            return true;
        }
        return false;
    }
}