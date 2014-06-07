using UnityEngine;
using System.Collections;

/// <summary>
/// Continue time after delayed time amount  
/// </summary>
public class Stept10 : MonoBehaviour
{

    public float playTime = 0F;
    public float delayTime = 0F;
    public float delayedAmount = 0F;
    public float delayNum = 0F;


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
        if (playTime > delayTime)
        {
            delayTime = Time.time + delayedAmount;
            Debug.Log("Delayed amount for"+ delayedAmount);
        }


    }



    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);
        GUILayout.Label("Delay Time: " + delayTime.ToString("0"));

    }
}
