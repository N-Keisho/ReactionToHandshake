using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCut : MonoBehaviour
{
    GameObject Panel;
    void Start()
    {
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.C))
        {
            Panel.SetActive(!Panel.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif
        }
    }
}
