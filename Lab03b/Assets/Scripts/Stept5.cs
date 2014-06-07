using UnityEngine;
using System.Collections;

public class Stept5 : MonoBehaviour
{

    public float playTime = 0F;
    public float startTime = 0F;
    public float fromStartTime = 0F;
    public float fromLoadTime = 0F;

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
            playTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //start time equals the current time (Time.time)
            startTime = Time.time;

        }
        CalculateFromStartTime();

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //startTime equals original level load time
            fromLoadTime = Time.timeSinceLevelLoad;
        }
    }


    /// <summary>
    /// Calculates from startTime counting up (starts at zero)
    /// </summary>
    private void CalculateFromStartTime()
    {
        fromStartTime = Time.time - startTime;
    }

    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);
        GUILayout.Label("Start Time: " + startTime);
        GUILayout.Label("From Start Time: " + fromStartTime);
        GUILayout.Label("From Load Time: " + fromLoadTime);
    }
}
