using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    void Start()
    {
        // canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    public void Settings()
    {
        canvas.enabled = !canvas.enabled;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit succesful");
    }
}
