using UnityEngine;
using System.Collections;

/// <summary>
/// Since startup time
/// Real Time since startup
/// </summary>
public class Stept12 : MonoBehaviour
{

    public float playTime = 0F;
    public float actualTime = 0F;




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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            actualTime = Time.realtimeSinceStartup;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 0F;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Time.timeScale = 1F;
        }



    }



    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);
        GUILayout.Label("Actual Time: " + actualTime);


    }
}
