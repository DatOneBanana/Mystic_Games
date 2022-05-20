using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {Water, Fire, Earth, Wood, Metal}

public class CharacterCombatStatus : MonoBehaviour 
{
    public string charName = "name";

    public int damage;

    public int maxHealth;
    public int currHealth;

    public int maxMana;
    public int currMana;

    public Type type;

    public bool TakeDamage(int dmg, Type attackingType)
    {
        if(TypeAdvantage(attackingType)) {
            dmg *= 2;
            currHealth -= dmg;
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
            dmg /= 2;
            currHealth -= dmg;
            if (currHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        currHealth -= dmg;
        if (currHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
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