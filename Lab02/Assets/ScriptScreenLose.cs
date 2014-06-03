using UnityEngine;
using System.Collections;

public class ScriptScreenLose : MonoBehaviour {


    void OnGUI()
    {
        //make a group on the center of the screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 200));

        //make a ox to see thhe group on the screen
        GUI.Box(new Rect(0, 0, 200, 100), "You Lose");
        //Instructios for the player
        GUI.Label(new Rect(10, 30 ,100, 50), "Score: "+PlayerPrefs.GetInt("SCORE"));

        //Add buttons here
        if (GUI.Button(new Rect(60, 60, 100, 30), "Back to menu"))
        {
            Application.LoadLevel("sceneMainMenu");
        }
        //End the group we started from above
        GUI.EndGroup();
    }
}
