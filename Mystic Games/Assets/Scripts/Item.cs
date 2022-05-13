using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Sword,
        //Bow,
        //Dagger,
        //Potion
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return 50;
            //case ItemType.Potion: return 10;
            //case ItemType.Dagger: return 20;
            //case ItemType.Bow: return 70;
        }

    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return GameAssets.i.sword;
            //case ItemType.Potion: return 10;
            //case ItemType.Dagger: return 20;
            //case ItemType.Bow: return 70;
        }
    }
}

