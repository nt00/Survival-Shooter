using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Light dirLight;
    public bool showMainMenu, showOptions;
    public GameObject mainMenu, options;

    public void MultiplayerButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void SingleplayerButton()
    {
        SceneManager.LoadScene(4);
    }

    public void AdjustBrightness(Slider slider)
    {
        dirLight.intensity = slider.value;
    }

    public void ShowOptions()
    {
        showOptions = true;
        showMainMenu = false;
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        showOptions = false;
        showMainMenu = true;
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void Windowed()
    {
        Screen.fullScreen = false;
    }

    void Start()
    {
        mainMenu.SetActive(true);
    }
}
