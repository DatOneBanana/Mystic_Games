using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPage : MonoBehaviour
{
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Play Tutorial");
        //Debug.Log("I went to the tutorial playthrough");
    }

}
