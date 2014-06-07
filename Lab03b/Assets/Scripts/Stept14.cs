using UnityEngine;
using System.Collections;

/// <summary>
/// Add more time to the timer 1. Single aomoun once 2- counting adding
/// </summary>
public class Stept14 : MonoBehaviour
{
    //part 2
    private float playTime;
    private float days = 0F;
    private float hours = 0F;
    private float minutes = 0F;
    private float seconds = 0F;
    private float fractions = 0F;

    // part 4
    private float startTime = 0F;
    private float fromStartTime = 0F;
    public bool playTimeEnabled = true;

    //part 5
    private float fromLoadTime = 0F;

    //part 6
    private float stopTime = 0F;
    private float pauseGameTime = 0F;
    //part 7
    private float continueTime = 0F;

    //stept 9
    private float countDowndelay = 0F;
    public float countDownAmount = 0F;

    //stept 10
    private float delayTime = 0F;
    public float delayedAmount = 0F;

    //styept 11
    private float addToTimeAmount = 0F;
    public float timeAmount = 0F;

    //stept 12
    private float actualTime = 0F;

    //stept13
    public bool countDownEnabled = false;


    // Use this for initialization
    void Start()
    {

    }

    // Simpl clock by geting the game time
    void Update()
    {

        Stept2();
        Stept3();
        Stept4();
        Stept5();
        stept6();
        Stept7();
        Stept8();
        Stept9();
        Stept12();
        Stept10();


    }

    private void Stept3()
    {
        //stept 1: start time
        if (playTimeEnabled)
        {
            playTime = Time.time - continueTime + addToTimeAmount;
        }

        if (playTimeEnabled && countDownEnabled)
        {
            //current time since start
            playTime = countDowndelay - Time.time + countDownAmount;
        }
    }

    private void Stept2()
    {

        playTime = Time.time;
        days = (playTime / 86400) % 365;
        hours = (playTime / 3600) % 24;
        minutes = (playTime / 60) % 60;
        seconds = (playTime % 60);
        fractions = (playTime * 10) % 10;
    }

    private void Stept12()
    {
        //stept 0 actual time since game start
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            actualTime = Time.realtimeSinceStartup;
        }
    }

    private void Stept10()
    {
           //stept 10 dealay amount /rate
        if (playTime > delayTime)
        {
            delayTime = Time.time + delayedAmount;
            Debug.Log("Delayed amount for" + delayedAmount);
        }
    }
    private void Stetpt11()
    {
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
    }

    private void Stept9()
    {
        //stept 7 count down time
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {

            countDowndelay = Time.time;
            playTimeEnabled = true;
            countDownEnabled = true;
        }
        if (playTime < 0)
        {
            countDownEnabled = false;
        }
    }

    private void Stept8()
    {
        //stept 6 reset time
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playTime = 0F;
            stopTime = 0F;
            playTimeEnabled = false;
        }
    }


    private void Stept4()
    {
  
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startTime = Time.time;

        }
        fromStartTime = Time.time - startTime;
    }

    private void Stept5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //startTime equals original level load time
            fromLoadTime = Time.timeSinceLevelLoad;
        }
    }

    private void Stept7()
    {
        //step 5: continue time
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            continueTime = Time.time - playTime;
            playTimeEnabled = true;
        }
    }

    private void stept6()
    {
        //stept 3: stop time (stoppin play time)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stopTime = Time.time;
            playTimeEnabled = false;
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
