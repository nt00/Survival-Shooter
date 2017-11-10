using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool cursorVisible = true;
    public bool showOptions;
    public GameObject options;
    public Light dirLight;

    void Start()
    {
        // Initially start the game with the cursor unlocked and visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Hiding and Showing mouse with tab toggle
        if (Input.GetButtonDown("Cursor"))
        {
            if (cursorVisible == true)
            {
                // Unlocks the cursor and becomes visible
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (cursorVisible == false)
            {
                // Locks the cursor and becomes invisible
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            cursorVisible = !cursorVisible;
        }

        if(Input.GetButtonDown("Options"))
        {
            showOptions = true;
            options.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Return()
    {
        showOptions = false;
        options.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AdjustBrightness(Slider slider)
    {
        dirLight.intensity = slider.value;
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void Windowed()
    {
        Screen.fullScreen = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
