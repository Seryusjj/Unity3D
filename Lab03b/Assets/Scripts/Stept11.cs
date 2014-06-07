using UnityEngine;
using System.Collections;

/// <summary>
/// Add more time to the timer 1. Single aomoun once 2- counting adding
/// </summary>
public class Stept11 : MonoBehaviour
{

    public float playTime = 0F;
    public float addToTimeAmount = 0F;
    public float timeAmount = 0F;



    public bool timeActive = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //enables time
        if (timeActive)
        {
            //current time since start
            playTime = Time.time + addToTimeAmount;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))//press to activate add to timer single amount
        {
            addToTimeAmount = timeAmount;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))//press to activate add to timer multiple amount
        {
            addToTimeAmount += timeAmount;
        }

    }



    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);
     

    }
}
