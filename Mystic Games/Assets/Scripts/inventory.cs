using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory 
{
    private List<Item> itemList;

    public void Inventory(){
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.sword, amount = 1});


        }


    
    public void AddItem(Item item) 
    {
        itemList.Add(item);
    }


}
