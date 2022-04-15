using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    public static bool mapIsOpen = false;
    public static bool scrollIsOpen = false;
    public GameObject mapUI;
    public GameObject scrollUI;
    // Start is called before the first frame update
    void Start()
    {
        CloseMap();
        CloseScroll();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            if(mapIsOpen) {
                CloseMap();
                CloseScroll();
            }
            else {
                OpenMap();
                OpenScroll();
            }
        }
    }

    void CloseMap() {
        mapIsOpen = false;
        mapUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void OpenMap() {
        mapIsOpen = true;
        mapUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void CloseScroll() {
        scrollIsOpen = false;
        scrollUI.SetActive(false);
    }

    void OpenScroll() {
        scrollIsOpen = true;
        scrollUI.SetActive(true);
    }    
}