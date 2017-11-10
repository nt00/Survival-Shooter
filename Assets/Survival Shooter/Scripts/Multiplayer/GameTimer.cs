using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float currentTime = 300f;
    public GUIStyle timerStyle;
    private float scrH, scrW;

    void Start()
    {
        //Setting screen height and width
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
    }

    void Update()
    {
        //The current time will be continually subtracted as the game continues
        currentTime -= Time.deltaTime;

        //If the time is less than or equal to zero, the game is over
        if (currentTime <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void OnGUI()
    {
        //Converting the current time into minutes and seconds to allow a cleaner look to the timer.
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string cleanTimer = string.Format("{0:0}:{1:00}", minutes, seconds);

        //Displays the timer on the GUI
        GUI.Label(new Rect(10, 10, 250, 100), cleanTimer, timerStyle);
    }
}