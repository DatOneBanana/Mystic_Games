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
         if(Input.GetKeyDown (KeyCode.I)){
            Square.SetActive(true);
 }
 else{Square.SetActive(false);}
        
    }
}
