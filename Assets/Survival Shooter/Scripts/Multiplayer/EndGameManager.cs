using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    void Start()
    {
        //Unlocks cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Loads Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
