using UnityEngine;
using System.Collections;

public class ScriptScreenLoad : MonoBehaviour
{
    //Inspector variables
    public float waitTime = 3.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("sceneLevel01");
        }
        else {
            StartCoroutine(WaitTime());
        }
	}

    void OnGUI()
    {
        //make a group on the center of the screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 200));

        //make a ox to see thhe group on the screen
        GUI.Box(new Rect(0, 0, 200, 200), "Instructios");
        //Instructios for the player
        GUI.Label(new Rect(10,30,140,40),"Arro keys to move");
        GUI.Label(new Rect(10, 60, 160, 70), "Space bar to shot");
        GUI.Label(new Rect(10, 90, 160, 100), "Letter E to activate shield");

        //End the group we started from above
        GUI.EndGroup();
    }

    private IEnumerator WaitTime() {
        
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("sceneLevel01");
    }
}
