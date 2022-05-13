using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
    [Serializable]

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

    public Sprite GetSprite(){
        switch(itemType)
        {
        default:
        case ItemType.sword: return ItemAssets.Instance.swordSprite;
        case ItemType.potion: return ItemAssets.Instance.potionSprite;
        case ItemType.coin: return ItemAssets.Instance.coinSprite;
        case ItemType.medkit: return ItemAssets.Instance.medkitSprite;
     

        }
    }

}
