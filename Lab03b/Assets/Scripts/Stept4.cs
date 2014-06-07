using UnityEngine;
using System.Collections;

public class Stept4 : MonoBehaviour {

    public float playTime =0F;
    public float startTime=0F;
    public float fromStartTime = 0F;

    public bool timeActive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timeActive)
        {
            playTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startTime = Time.time;

        }
        fromStartTime = Time.time - startTime;
	}

    void OnGUI()
    {
        GUILayout.Label("Play Time: "+playTime);
        GUILayout.Label("Start Time: " + startTime);
        GUILayout.Label("From Start Time: " + fromStartTime);
    }
}
