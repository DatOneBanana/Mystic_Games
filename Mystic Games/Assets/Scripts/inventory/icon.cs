using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class icon : MonoBehaviour
{
    // Start is called before the first frame update
    public enum InteractionType {NONE, PickUp}
    public InteractionType type;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 5;
    }
    public void Interact(){

        switch(type)
        {
            case InteractionType.PickUp:
            //add obj to list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                gameObject.SetActive(false);
            //del item
            Debug.Log("pickup");
            break;
            default:
            Debug.Log("null item");
            break;
        }

        }
    
}
