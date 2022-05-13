using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string nameWeapon;
    public int damage;
    public int weight;
    public WeaponType weaponT;
    public DamageType type;


    public Weapon(string n, int d, int w, WeaponType wt, DamageType t)
    {
        nameWeapon = n;
        damage = d;
        weight = w;
        weaponT = wt;
        type = t;
    }

}


public enum WeaponType
{
    Sword,
    Bow,
    Dagger
}

public enum DamageType
{
    Normal,
    Wood,
    Fire,
    Earth,
    Metal,
    Water
}
