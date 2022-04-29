using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon("GodSlayer", 100, 50, WeaponType.sword, DamageType.normal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
