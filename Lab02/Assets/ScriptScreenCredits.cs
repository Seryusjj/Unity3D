using UnityEngine;
using System.Collections;

public class ScriptScreenCredits : MonoBehaviour
{



    void OnGUI()
    {
        //make a group on the center of the screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 220));

        //make a ox to see thhe group on the screen
        GUI.Box(new Rect(0, 0, 200, 220), "Credits");
        //Instructios for the player
        GUI.Label(new Rect(10, 40, 200, 50), "Designer      Sergio Jiémenez");
        GUI.Label(new Rect(10, 70, 200, 80), "Artist            Sergio Jiménez");
        GUI.Label(new Rect(10, 100, 200, 110), "Software        Sergio Jiménez");
        GUI.Label(new Rect(10, 130, 200, 140), "Level Designer  Sergio Jiménez");
        //Add buttons here
        if (GUI.Button(new Rect(60, 175, 100, 30), "Back to menu"))
        {
            Application.LoadLevel("sceneMainMenu");
        }
        //End the group we started from above
        GUI.EndGroup();
    }
}
