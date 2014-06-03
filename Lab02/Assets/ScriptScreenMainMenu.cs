using UnityEngine;
using System.Collections;

public class ScriptScreenMainMenu : MonoBehaviour {
    

    void OnGUI()
    {
        //make a group on the center of the screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 100, 175));

        //make a ox to see thhe group on the screen
        GUI.Box(new Rect(0,0,100,175),"Main menu");

        //Add buttons for game navigation
        if (GUI.Button(new Rect(10, 30, 80, 30), "Start Game")) {
            Application.LoadLevel("sceneLoad");
        }

        //Add buttons for game navigation
        if (GUI.Button(new Rect(10, 65, 80, 30), "Credits"))
        {
            Application.LoadLevel("sceneCredit");
        }
        //Add buttons for game navigation
        if (GUI.Button(new Rect(10, 100, 80, 30), "Exit"))
        {
            Application.Quit();
        }
        //Add buttons for game navigation
        if (GUI.Button(new Rect(10, 135, 80, 30), "Home Page"))
        {
            Application.OpenURL("http://seryux.servebeer.com");
        }

        GUI.EndGroup();
    }


}
