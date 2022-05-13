using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    //Start is called before the first frame update
   //instantiate prefav from  itemassets
   //sets item to itemworld
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld,position,Quaternion.identity);
        
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    private Item item; //setter
    private SpriteRenderer spriteRenderer;
   
    //will return watever come from getSprite
    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
    public Item GetItem(){
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    
}
