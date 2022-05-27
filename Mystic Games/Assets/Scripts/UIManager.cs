using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    LevelLoader b;
//subscribe
    
    private void OnEnable()
    {
        HealthBar.onPlayerDeath += EnableGameOverMenu;
    }
//unsubscribe(retry) or sets gameover menu to false

    private void OnDisable()
    {
        HealthBar.onPlayerDeath -= EnableGameOverMenu;

    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void DisableGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }
    
    public void RestartLevel()
    {
     Debug.Log("clicked");
      SceneManager.LoadScene(8);
        
    }

}
