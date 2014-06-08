using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    public float walkSpeed = 1.5F;
    public float runSpeed = 2.0F;
    public float fallSpeed = 2.0F;
    public float walkJump = 6.0F;
    public float runJump = 9.0F;
    public float crouchJump = 10.0F;
    public float gravity = 20F;

    private int moveDirection = 1;

    private Vector3 velocity = Vector3.zero;


    //private variables
    private AnimationSprite animator;
    private CharacterController marioControl;




    void Update()
    {
        Controls();
    }



    private void Controls()
    {
        if (marioControl.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            ControlJump();
        }
        else
        {
            velocity.x = Input.GetAxis("Horizontal");
            velocity.x *= walkSpeed;
        }
        velocity.y -= gravity * Time.deltaTime;
        marioControl.Move(velocity * Time.deltaTime);
    }

    private void ControlJump()
    {
        //walk jump
        if (Input.GetButtonDown("Jump") && Input.GetButton("Fire1"))
        {
            velocity.y = runJump;
        }
        //run jump
        if (Input.GetButtonDown("Jump") && !Input.GetButton("Fire1"))
        {
            velocity.y = walkJump;
        }
    }


    void Start()
    {
        animator = CreateAnimator();
        marioControl = GetComponent<CharacterController>();
    }

    private AnimationSprite CreateAnimator()
    {
        int columnSize = 16;
        int rowSize = 16;
        int colFrameStart = 0;
        int rowFrameStart = 1;
        int totalFrames = 16;
        float framesPerSecond = 12;
        return new AnimationSprite(columnSize, rowSize, colFrameStart, rowFrameStart, totalFrames, framesPerSecond);

    }
}
