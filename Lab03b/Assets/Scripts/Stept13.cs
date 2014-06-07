using UnityEngine;
using System.Collections;

/// <summary>
/// Add more time to the timer 1. Single aomoun once 2- counting adding
/// </summary>
public class Stept13 : MonoBehaviour
{
    //part 2
    public float playTime;
    public float days = 0F;
    public float hours = 0F;
    public float minutes = 0F;
    public float seconds = 0F;
    public float fractions = 0F;

    // part 4
    public float startTime = 0F;
    public float fromStartTime = 0F;
    public bool timeActive = true;

    //part 5
    public float fromLoadTime = 0F;

    //part 6
    public float stopTime = 0F;
    public float pauseGameTime = 0F;
    //part 7
    public float continueTime = 0F;

    //stept 9
    public float countDowndelay = 0F;
    public float countDownAmount = 0F;

    //stept 10
    public float delayTime = 0F;
    public float delayedAmount = 0F;

    //styept 11
    public float addToTimeAmount = 0F;
    public float timeAmount = 0F;

    //stept 12
    public float actualTime = 0F;

    //stept13
    public bool countDownEnabled = false;


    // Use this for initialization
    void Start()
    {

    }

    // Simpl clock by geting the game time
    void Update()
    {

        playTime = Time.time;
        days = (playTime / 86400) % 365;
        hours = (playTime / 3600) % 24;
        minutes = (playTime / 60) % 60;
        seconds = (playTime % 60);
        fractions = (playTime * 10) % 10;

        if (timeActive)
        {
            playTime = Time.time - continueTime + addToTimeAmount;
        }
        if (!timeActive && countDownEnabled)
        {
            //current time since start
            playTime = countDowndelay - Time.time + countDownAmount;
        }

        //stept 1: start time
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startTime = Time.time;

        }
        fromStartTime = Time.time - startTime;

        //stept 2 from load time
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //startTime equals original level load time
            fromLoadTime = Time.timeSinceLevelLoad;
        }

        //stept 3: stop time (stoppin play time)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stopTime = Time.time;
            timeActive = false;
        }

        //stept 4: stop game time (pause game)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Time.timeScale = 0F;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Time.timeScale = 1F;
        }
        pauseGameTime = Time.time;

        //step 5: continue time
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            continueTime = Time.time - playTime;
            timeActive = true;
        }

        //stept 6 reset time
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playTime = 0F;
            stopTime = 0F;
            timeActive = false;
        }

        //stept 7 count down time
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            
            countDowndelay = Time.time;
            timeActive = false;
            countDownEnabled = true;
        }
        if (playTime < 0)
        {
            timeActive = false; 
        }

        //stetpt 8 add to time a single / once
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            addToTimeAmount = timeAmount;
        }
        //stept 9 add to time (continuous)
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            addToTimeAmount += timeAmount;
        }

        //stept 0 actual time since game start
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            actualTime = Time.realtimeSinceStartup;
        }

        //stept 10 dealay amount /rate
        if (playTime > delayTime)
        {
            delayTime = Time.time + delayedAmount;
            Debug.Log("Delayed amount for" + delayedAmount);
        }


    }

    void OnGUI()
    {
        GUILayout.Label("Play time: " + playTime);
        GUILayout.Label("Minutes: " + minutes.ToString("0"));
        GUILayout.Label("Seconds: " + seconds.ToString("0"));
        GUILayout.Label("Fractions: " + fractions.ToString("0.000"));
        GUILayout.Label("Start Time: " + startTime);
        GUILayout.Label("From Start Time: " + fromStartTime);
        GUILayout.Label("From Load Time: " + fromLoadTime);
        GUILayout.Label("stop Time: " + stopTime);
        GUILayout.Label("Pause Game Time: " + pauseGameTime);
        GUILayout.Label("Delay Time: " + delayTime.ToString("0"));
        GUILayout.Label("Actual Time: " + actualTime);
    }
}
