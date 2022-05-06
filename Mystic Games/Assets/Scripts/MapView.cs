using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    public static bool mapIsOpen = false;
    public GameObject mapUI;

    // Start is called before the first frame update
    void Start()
    {
        CloseMap();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            if(mapIsOpen) {
                CloseMap();
            }
            else {
                OpenMap();
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
}