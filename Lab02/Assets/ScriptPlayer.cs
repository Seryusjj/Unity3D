using UnityEngine;
using System.Collections;

public class ScriptPlayer : MonoBehaviour
{

    //inspector variables
    public float playerSpeedVertical = 10.0F;
    public float playerSpeedHorizontal = 10.0F;


    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {

        Controller();

    }


    private void Controller()
    {
        /*
            manera rudimentaria
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            }
         */

        float transV = Input.GetAxis("Vertical")*playerSpeedVertical * Time.deltaTime;
        float transH= Input.GetAxis("Horizontal") * playerSpeedHorizontal * Time.deltaTime;
        transform.Translate(transH,transV,0);
        CheckLimits();
    }

    private void CheckLimits()
    {
        
        float xlimit = 6.1F;
        float ylimit = 4.4F;
        /*manera rudimentaria
        if (transform.position.x >= xlimit)
        {
            transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -xlimit)
        {
            transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= ylimit)
        {
            transform.position = new Vector3(transform.position.x, ylimit, transform.position.z);
        }
        if (transform.position.y <= -ylimit)
        {
            transform.position = new Vector3(transform.position.x, -ylimit, transform.position.z);
        }*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-xlimit,xlimit), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -ylimit, ylimit), transform.position.z);


    }
}
