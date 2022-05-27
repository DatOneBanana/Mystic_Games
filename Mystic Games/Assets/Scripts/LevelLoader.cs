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
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public GameObject music;
    public GameObject healthBar;
    public GameObject manaBar;

    public Animator transition;
    public float transitionTime = 1f;

    public void LoadLevel(string sceneName) 
    {
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
        manaBar.SetActive(false);
    }

    public void EnableSceneUI()
    {
        music.SetActive(true);
        healthBar.SetActive(true);
        manaBar.SetActive(true);
    }
}
