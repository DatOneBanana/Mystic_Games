using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        //Debug.Log("I clicked the Tutorial Button");
    }

    public void QuitGame()
    {
        Debug.Log("The game has quit.");
        Application.Quit();    
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Health Bar Test");
    }
}
