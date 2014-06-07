using UnityEngine;
using System.Collections;

/// <summary>
/// Reset the current time and/or stopped time to 0
/// </summary>
public class Stept8 : MonoBehaviour
{

    public float playTime = 0F;
    public float stopTime = 0F;
    public float continueTime = 0F;


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
            playTime = Time.time -continueTime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stopTime = Time.time;
            timeActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            continueTime = Time.time - playTime;
            timeActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playTime = 0F;
            stopTime = 0F;
            timeActive = false;
        }

    }



    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);
        GUILayout.Label("stop Time: " + stopTime);
        GUILayout.Label("Time: " + Time.time);

    }
}
