using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GirlScript : MonoBehaviour
{
    public GameObject text;

    public void Start()
    {
        text.SetActive(false);
    }

    public void Update()
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