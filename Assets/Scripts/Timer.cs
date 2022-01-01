using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float startTime;

    public GameObject player;
    private bool Finished = false;

    public string minutes;
    public string seconds;

    public static string Min;
    public static string Sec;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float t = Time.time - startTime;

            if (Finished)
                return;

            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");
            
            Min = ((int)t / 60).ToString();
            Sec = (t % 60).ToString("f2");

            TimerText.text = minutes + ":" + seconds;

            string.Compare(minutes, seconds);
        }            
            
    }

    public void Finish()
    {
        Finished = true;
    }

    public static string GetTime()
    {
        return Min + ":" + Sec;
    }

}
