using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public GameObject text;

    public void Start()
    {
        
    }
    
    public void DisableText()
    {
        text.SetActive(false);
    }

    public void EnableText()
    {
        text.SetActive(true);
    }
}
