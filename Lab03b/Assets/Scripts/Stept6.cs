using UnityEngine;
using System.Collections;

/// <summary>
/// two types 1: Stops current playTime 2: Stops / Pause Game Time
/// </summary>
public class Stept6 : MonoBehaviour
{

    public float playTime = 0F;
    public float stopTime = 0F;
    public float pauseGameTime = 0F;


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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stopTime = Time.time;
            timeActive = false;
        }
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
        GUILayout.Label("Play Time: " + playTime);
        GUILayout.Label("stop Time: " + stopTime);
        GUILayout.Label("Pause Game Time: " + pauseGameTime);

    }
}
