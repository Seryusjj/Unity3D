using UnityEngine;
using System.Collections;

/// <summary>
/// Count Down time 
/// 
/// </summary>
public class Stept9 : MonoBehaviour
{

    public float playTime = 0F;
    public float countDowndelay = 0F;
    public float countDownAmount = 0F;



    public bool timeActive = false;
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
            playTime = countDowndelay - Time.time +countDownAmount;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            countDowndelay = Time.time;
            timeActive = true;
        }
        if(playTime < 0){
            timeActive = false;
        }
       

    }



    void OnGUI()
    {
        GUILayout.Label("Play Time: " + playTime);


    }
}
