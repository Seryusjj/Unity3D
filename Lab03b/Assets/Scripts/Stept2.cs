using UnityEngine;
using System.Collections;

public class Stept2 : MonoBehaviour
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

    // Simpl clock by geting the game time
    void Update()
    {

        playTime = Time.time;
        days = (playTime / 86400) % 365;
        hours = (playTime / 3600) % 24;
        minutes = (playTime / 60) % 60;
        seconds = (playTime % 60);
        fractions = (playTime * 10) % 10;
        
       // Debug.Log(string.Format("Minutes: {0} Seconds: {1} Fractions: {2}", minutes, seconds, fractions));
        if(seconds>= 30){
            Debug.Log("you are in the thirty second mark");
        }
        if (minutes >= 1)
        {
            Debug.Log("You are at the one minute mark");
        }

    }
}
