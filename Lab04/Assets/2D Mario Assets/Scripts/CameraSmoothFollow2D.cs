using UnityEngine;
using System.Collections;

public class CameraSmoothFollow2D : MonoBehaviour {

    public GameObject cameraTargect;
    public GameObject player;

    public float smoothTime = 0.1F;
    public bool cameraFollowX = true;
    public bool cameraFollowY = true;

    public bool cameraFollowHeight = true;
    public float cameraHeight = 2.5F;
    public bool cameraZoom = false;
    public float cameraZoomMax = 3F;
    public float cameraZoomMin = 2.7F;
    public float cameraZoomTime = 0.03F;


    public Vector2 velocity;

    private Transform thisTransform;
    private Vector3 currentPosition;//current position of cameraTarget
    private float playerJumpHeight=0F;//store height of player
    private PlayerControl playerControl;


	void Start () {
        thisTransform = this.transform;
        playerControl=player.GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraFollowX)
        {
            float x = Mathf.SmoothDamp(thisTransform.position.x, cameraTargect.transform.position.x, ref velocity.x, Time.deltaTime);
            this.transform.position = new Vector3(x,this.transform.position.y,this.transform.position.z);
        }
        if(cameraFollowY){
            float y = Mathf.SmoothDamp(thisTransform.position.y, cameraTargect.transform.position.y, ref velocity.y, Time.deltaTime);
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
        if(!cameraFollowY && cameraFollowHeight){
            camera.transform.position = new Vector3(camera.transform.position.x, cameraHeight, camera.transform.position.z);
        }
        if(cameraZoom){
            Zoom();

        }
	}

    private void Zoom()
    {
        //get current position of players current y position 
        currentPosition = player.transform.position; //set current position to payers current position

        //check for the player position and how it relates to the currentPosition and currentJumpHeight
        playerJumpHeight = currentPosition.y - playerControl.stratPosition.y;//substractingthe current height from the player control start position


        if (playerJumpHeight < 0)
        {
            playerJumpHeight *= -1;
        }
        if (playerJumpHeight > cameraZoomMax)
        {
            cameraHeight = cameraZoomMax;
        }

        //adjust the orthographic size from camera to equal the jump height distance 
        this.camera.orthographicSize = Mathf.Lerp(this.camera.orthographicSize,playerJumpHeight+cameraZoomMin, Time.time * cameraZoomTime);
    }
}
