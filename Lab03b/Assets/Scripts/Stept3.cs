using UnityEngine;
using System.Collections;

public class Stept3 : MonoBehaviour
{
    public float playTime;
    public float days = 0F;
    public float hours = 0F;
    public float minutes = 0F;
    public float seconds = 0F;
    public float fractions = 0F;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        playTime = Time.time;
        days = (playTime / 86400) % 365;
        hours = (playTime / 3600) % 24;
        minutes = (playTime / 60) % 60;
        seconds = (playTime % 60);
        fractions = (playTime * 10) % 10;

        // Debug.Log(string.Format("Minutes: {0} Seconds: {1} Fractions: {2}", minutes, seconds, fractions));
        if (seconds >= 30)
        {
            Debug.Log("you are in the thirty second mark");
        }
        if (minutes >= 1)
        {
            Debug.Log("You are at the one minute mark");
        }

    }

    void OnGUI()
    {
        GUILayout.Label("Play time: " + playTime);
        GUILayout.Label("Minutes: " + minutes.ToString("0"));
        GUILayout.Label("Seconds: " + seconds.ToString("0"));
        GUILayout.Label("Fractions: " + fractions.ToString("0.000"));
    }
}
