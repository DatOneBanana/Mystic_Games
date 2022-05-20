using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPage : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Brandon");
        //Debug.Log("I went to the tutorial playthrough");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
