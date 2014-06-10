using UnityEngine;
using System.Collections;

public class CameraBorderFollow2D : MonoBehaviour
{

    public GameObject cameraTarget;//object to look up/follow
    public GameObject player;//player object for moving

    public float cameraHeight = 0F;
    public float smoothTime = 0.2F;
    public float borderX = 0.2F;  //amount to move to the right
    public float borderY = 0.2F;

    private Vector2 velocity;
    private bool moveScreenRight = false;
    private bool moveScreenLeft = false;


    private PlayerControl playerControl;




    // Use this for initialization
    void Start()
    {
        cameraHeight = camera.transform.position.y;
        playerControl = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

        MoeveEdgeRight();
        MoveEdgeLeft();
        MoeveEdgeHeight();
        
    }

    private void MoveEdgeLeft()
    {
        if (cameraTarget.transform.position.x < camera.transform.position.x - borderX && playerControl.moveDirection == 0)
        {
            moveScreenLeft = true;
           
        }
        if (moveScreenLeft)
        {
            float x = Mathf.SmoothDamp(camera.transform.position.x, camera.transform.position.x - borderX, ref velocity.y, smoothTime);
            camera.transform.position = new Vector3(x, camera.transform.position.y, camera.transform.position.z);//adjust vertical
        }
        if (cameraTarget.transform.position.x > camera.transform.position.x + borderX && playerControl.moveDirection == 0)
        {
            moveScreenLeft = false;
        }
    }

    private void MoeveEdgeRight()
    {
        if (cameraTarget.transform.position.x > camera.transform.position.x + borderX && playerControl.moveDirection == 1)
        {
            moveScreenRight = true;
         
        }
        if (moveScreenRight)
        {
            float x = Mathf.SmoothDamp(camera.transform.position.x, camera.transform.position.x + borderX, ref velocity.y, smoothTime);
            camera.transform.position = new Vector3(x, camera.transform.position.y, camera.transform.position.z);//adjust vertical
        }
        if (cameraTarget.transform.position.x < camera.transform.position.x - borderX && playerControl.moveDirection == 1)
        {
            moveScreenRight = false;
        }
        
    }
    private void MoeveEdgeHeight()
    {
        camera.transform.position = new Vector3(camera.transform.position.x,cameraHeight,camera.transform.position.z);

    }
}
