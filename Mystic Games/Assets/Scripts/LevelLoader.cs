using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    #region Singleton
    public static LevelLoader instance;

    void Awake() 
    {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public GameObject music;
    public GameObject healthBar;
    public GameObject player;
    public GameObject tempEnemy;
    public GameObject gameOver;
    
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadLevel(string sceneName) 
    {
        StartCoroutine(LoadNamedLevel(sceneName));
    }

    public void LoadLevel(string sceneName, GameObject enemy) 
    {
        tempEnemy = enemy;
        StartCoroutine(LoadNamedLevel(sceneName));
    }

    IEnumerator LoadNamedLevel(string sceneName)
    {
        //Starts animation for transition
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        //Ends animation for transition
        transition.SetTrigger("End");
        
    }

    public void UnloadLevel(string sceneName)
    {
        StartCoroutine(UnloadNamedLevel(sceneName));
        tempEnemy = null;
    }

    IEnumerator UnloadNamedLevel(string sceneName)
    {
        //Starts animation for transition
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.UnloadSceneAsync(sceneName);

        //Ends animation for transition
        transition.SetTrigger("End");
    }

    public void DisableSceneUI()
    {
        music.SetActive(false);
        healthBar.SetActive(false);
    }

    public void EnableSceneUI()
    {
        music.SetActive(true);
        healthBar.SetActive(true);
        player.GetComponent<Player>().currentHealth = player.GetComponent<CharacterCombatStatus>().currHealth;
        healthBar.GetComponent<HealthBar>().SetHealth(player.GetComponent<Player>().currentHealth);
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("Brandon");
    }

    public IEnumerator EnableGameOverMenu()
    {
        yield return new WaitForSeconds(transitionTime);

        gameOver.SetActive(true);
    }
}
