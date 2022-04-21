using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Square;

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
            if (!Square.activeSelf) 
            {Square.SetActive(true);
                Debug.Log("open");
            }
            else {Square.SetActive(false);
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
