using UnityEngine;
using System.Collections;

public class ScriptMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Show what the user should see on the screen, this function is call by the Unity engine 
    /// </summary>
    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,90,50),"Start Game")){
            Application.LoadLevel("sceneScreenLevel1");


        }
        if (GUI.Button(new Rect(10,70,90,50),"Exit game")) {
            Application.Quit();
        }
    }
}
