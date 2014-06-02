using UnityEngine;
using System.Collections;

public class ScriptScreenWin : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Show what the user should see on the screen, this function is call by the Unity engine 
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 40), "YOU WIN!!");
        if (GUI.Button(new Rect(10, 60, 90, 50), "Restart Game"))
        {
            Application.LoadLevel("sceneScreenLevel1");


        }
        if (GUI.Button(new Rect(10, 130, 90, 50), "Exit game"))
        {
            Application.Quit();
        }
    }
}
