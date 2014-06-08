using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private float walkSpeed = 1.5F;
    private float runSpeed = 2.0F;
    private float fallSpeed = 2.0F;
    private float walkJump = 6.0F;
    private float runJump = 9.0F;
    private float crouchJump = 6.0F;
    private float gravity = 20F;

    private int moveDirection = 1; //1 for the right, 0 for the left

    private Vector3 velocity = Vector3.zero;


    //private variables
    private AnimationSprite animator;
    private CharacterController marioControl;




    void Update()
    {
        Controls();
    }


    /// <summary>
    /// The controlsof super mario
    /// </summary>
    private void Controls()
    {
        if (marioControl.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            IdleAnimation();
            WalkAnimation();
            RunAnimation();
            CrouchAnimation();
            ControlJump();
        }
        else
        {
            ControlPostJump();
            
        }

        CheckCurrentDirection();
        velocity.y -= gravity * Time.deltaTime;
        marioControl.Move(velocity * Time.deltaTime);

    }



    /// <summary>
    /// Updates de moveDirection variable in order to 
    /// correctluy choose the animation
    /// </summary>
    private void CheckCurrentDirection()
    {
        if (velocity.x < 0)
        {
            moveDirection = 0;

        }
        else if (velocity.x > 0)
        {
            moveDirection = 1;
        }
    }

    /// <summary>
    /// Play the idle animation of mario either to the right
    /// or the left, depens on de moveDirection variable state
    /// </summary>
    private void IdleAnimation()
    {
        //idle right
        if (velocity.x == 0 && moveDirection == 1)
        {
            animator.SetRowFrameStart(0).SetTotalFrames(16).SetFramesPerSecond(12);
            animator.Animate(gameObject, Time.time);
        }
        //idle left
        else if (velocity.x == 0 && moveDirection == 0)
        {
            animator.SetRowFrameStart(1).SetTotalFrames(16).SetFramesPerSecond(12).SetRowSize(16);
            animator.Animate(gameObject, Time.time);
        }
    }

    /// <summary>
    /// es: "agacharse"
    /// </summary>
    private void CrouchAnimation()
    {
        if (velocity.x == 0 && Input.GetAxis("Vertical") < 0)
        {
            velocity.x = 0;
            //right
            if (moveDirection == 1)
            {
                animator.SetRowFrameStart(8).SetTotalFrames(16).SetFramesPerSecond(24);
                animator.Animate(gameObject, Time.time);
            }
            else //left
            {
                animator.SetRowFrameStart(9).SetTotalFrames(16).SetFramesPerSecond(24);
                animator.Animate(gameObject, Time.time);
            }
        }
    }

    /// <summary>
    /// Play the walk animation of mario either to the right
    /// or the left and control mario velocity
    /// </summary>
    private void WalkAnimation()
    {
        //walk right
        if (velocity.x > 0 && !Input.GetButton("Fire1"))
        {
            velocity *= walkSpeed;
            animator.SetRowFrameStart(2).SetTotalFrames(10).SetFramesPerSecond(15);
            animator.Animate(gameObject, Time.time);
        }
        //walk left
        else if (velocity.x < 0 && !Input.GetButton("Fire1"))
        {
            velocity *= walkSpeed;
            animator.SetRowFrameStart(3).SetTotalFrames(10).SetFramesPerSecond(15);
            animator.Animate(gameObject, Time.time);
        }
    }

    /// <summary>
    /// Play the run animation of mario either to the right
    /// or the left and control mario velocity
    /// </summary>
    private void RunAnimation()
    {
        //walk right
        if (velocity.x > 0 && Input.GetButton("Fire1"))
        {
            velocity *= runSpeed;
            animator.SetRowFrameStart(4).SetTotalFrames(16).SetFramesPerSecond(24);
            animator.Animate(gameObject, Time.time);
        }
        //walk left
        else if (velocity.x < 0 && Input.GetButton("Fire1"))
        {
            velocity *= runSpeed;
            animator.SetRowFrameStart(5).SetTotalFrames(16).SetFramesPerSecond(24);
            animator.Animate(gameObject, Time.time);
        }
    }

    /// <summary>
    /// What to do after jumping: put the player again in the ground
    /// and perform several chekouts
    /// </summary>
    private void ControlPostJump()
    {

    }

    private void ControlJump()
    {
        //walk jump

        if (Input.GetButtonDown("Jump") && (!Input.GetButton("Fire1") || (Input.GetButton("Fire1") && velocity.x == 0)) && Input.GetAxis("Vertical") >= 0)
        {
            velocity.y = walkJump;
        }//run jump
        else if (Input.GetButtonDown("Jump") && Input.GetButton("Fire1") && velocity.x != 0)
        {
            velocity.y = runJump;
        }//walk jump//crouch jump
        else if (Input.GetButton("Jump") && Input.GetAxis("Vertical") < 0 && velocity.x == 0)
        {
            velocity.y = crouchJump;
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
