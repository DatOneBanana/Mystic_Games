using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Inventory;
  //   private Inventory inventory;
  //  //chanfes get updated
  //  private Transform itemContainer;
  //  private Transform itemContainerTemplate;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
         if(Input.GetKeyDown (KeyCode.I))
         { 
            
             //release
            if (!Inventory.activeSelf) 
            {Inventory.SetActive(true);
          // Panel.transform.GetChild(1).gameObject.SetActive(true);
                Debug.Log("open");

            }
            else {Inventory.SetActive(false);
            
          Debug.Log("close");
            }
         }
         /**
        if(Input.GetKeyUp (KeyCode.I))
         {
            Square.SetActive(false);
          Debug.Log("gone");
         }**/
                
    }
}
