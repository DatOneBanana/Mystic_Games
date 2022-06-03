using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallScript : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text text;

    public void Start()
    {
        textBox.SetActive(false);
    }

    public void DisableText()
    {
        textBox.SetActive(false);
    }

    public void EnableText(int count)
    {
        text.text = "You have only killed " + count + " out of the 10 enemies.";
        textBox.SetActive(true);
    }
}
