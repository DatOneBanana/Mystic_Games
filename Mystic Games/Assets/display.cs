using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;

    // void Start()
    // {
    //     //Square.show = false;
    // }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown (KeyCode.I))
         { 

             //release
            if (!Panel.activeSelf) 
            {Panel.SetActive(true);
                Debug.Log("open");
            }
            else {Panel.SetActive(false);
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
