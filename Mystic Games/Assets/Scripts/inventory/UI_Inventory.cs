using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
   private Inventory inventory;
   //chanfes get updated
   private Transform itemContainer;
   private Transform itemContainerTemplate;

   public void Awake(){
       itemContainer = transform.Find("itemContainer");
       itemContainerTemplate = itemContainer.Find("itemContainerTemplate");
   }
   public void SetInventory(Inventory inventory)
   {
       this.inventory = inventory;
       RefreshInventoryItems();
   }
   //cyc/e thru all items in the inventory

   private void RefreshInventoryItems(){
       int x = 0;
       int y = 0;
       
       float itemSlotCellSize = 45f;
       

       foreach(Item item in inventory.GetItemList())
       {
           
           RectTransform itemSlotRectTransform = 
           Instantiate(itemContainerTemplate,itemContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           //locate slots in grid array
           itemSlotRectTransform.anchoredPosition = new Vector2( x * itemSlotCellSize, y * itemSlotCellSize);
       Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
       image.sprite = item.GetSprite();
       x++;
       if(x>5){
           x=0;
           y--;
           
       }
       }
   }
}
