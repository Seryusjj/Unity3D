using UnityEngine;
using System.Collections;

public class ScriptPlayer : MonoBehaviour
{
    private const int LEFTCLICK = 0;
    private const int RIGHTCLICK = 1;
    private const int MIDDLECLICK = 2;

    //this two must be public in order to allow the designer to change it's value from the editor
    public const string targetTagName = "enemy";
    public float rayDistance = 100;
    private int points;
    public float gametime = 20.0F;//the time that the game will last in secodns
    public int pointsToWin = 360;


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        GetMouseButton();
    }


    /// <summary>
    /// Method used for initialization
    /// </summary>
    void Start()
    {
        InvokeRepeating("ConsumeGameTime", 1.0F, 1.0F);
    }

    /// <summary>
    /// Substract the game time and swicht the scene
    /// </summary>
    private void ConsumeGameTime()
    {
        if (--gametime == 0)
        {
            //calcel the countdown when time == 0
            CancelInvoke("ConsumeGameTime");
            WinOrLose();
            
        }
    }

    private void WinOrLose() {
        if (points< 500)
        {
            Application.LoadLevel("sceneScreenLose");
        }
        else {
            Application.LoadLevel("sceneScreenWin");
        }
    }


    /// <summary>
    /// Check in yo hit yuo hit the object that is in the position that you're pointing at
    /// </summary>
    private void checkIfClicked()
    {

        RaycastHit hit;
        //A ray is an infinite line starting at origin and going in some direction.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Relocate(hit.transform.tag.Equals("enemy"), hit);
        }
    }

    /// <summary>
    /// Realoate the enemys once the're hitted
    /// </summary>
    /// <param name="haveToAct"></param>
    /// <param name="hit"></param>
    private void Relocate(bool haveToAct, RaycastHit hit)
    {
        if (haveToAct)
        {
            ScriptEnemy enemyscript = hit.transform.GetComponent<ScriptEnemy>();
            enemyscript.numberOfclicks -= 1;
            //add points when destroying a shape
            if (enemyscript.numberOfclicks <= 0)
            {
                points += enemyscript.enemyPoint;
            }

            Debug.Log("you hit an enemy.");
        }
        else
        {
            Debug.Log("This is not anenemy.");
        }
    }

    /// <summary>
    /// check if yhe player is clicking the right mouse button
    /// </summary>
    private void GetMouseButton()
    {

        if (Input.GetMouseButton(LEFTCLICK))
        {

            Debug.Log("Pressed left click.");
            checkIfClicked();

        }

    }

    /// <summary>
    /// Show what the user should see on the screen, this function is call by the Unity engine 
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,20),"Score: "+points);
        GUI.Label(new Rect(10, 25, 100, 35), "Time: " + gametime);
    }

}
