using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //make item type
    public enum ItemType {
        sword,
        potion,
        coin,
        medkit
    }
    //now other files can use this
    public ItemType itemType;
    public int amount;

}
