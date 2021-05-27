using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeText;

    public float totaltime;

    public float minutes;
    public float seconds;

    private bool gamePaused = false;

    public static bool clicked = false;


    public void Update()
    {
        if (!gamePaused)
            totaltime -= Time.deltaTime;
        minutes = (int)(totaltime / 60);
        seconds = (int)(totaltime % 60);

        if (minutes == 0 && seconds == 0)
        {
            SceneManager.LoadScene(4);
        }

        timeText.GetComponent<Text>().text = minutes.ToString() + ":" + seconds.ToString();

    }




}
