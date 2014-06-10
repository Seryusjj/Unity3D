using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    //inspector variables

    //sounds
    public AudioClip soundJump;
    public AudioClip soundCrouchJump;

    //particles
    public Transform particleJump;

    public Vector3 stratPosition;//for the zoom

    //private variables
    private float walkSpeed = 1.5F;
    private float runSpeed = 2.0F;
    private float fallSpeed = 2.0F;
    private float walkJump = 6.0F;
    private float runJump = 9.0F;
    private float crouchJump = 10.0F;
    public float gravity = 20F;

    public int moveDirection = 1; //1 for the right, 0 for the left

    private Vector3 velocity = Vector3.zero;

    private AnimationSprite animator;
    private CharacterController controller;

    private bool jumpEnabled;
    private bool runJumpEnabled;
    private bool crouchJumpEnabled;
    private float afterHitForceDown = 1.0F; //force player down if hitted on the head


    private float soundRate = 0F;
    private float soundDelay = 0F;

    private Vector3 particlePlacement;


    void Update()
    {
        particlePlacement = new Vector3(transform.position.x, transform.position.y-0.5F, transform.position.z);
        Controls();
    }



    private IEnumerator PlaySoundCorrutine(AudioClip soundName, float soundDelay)
    {
        if (!audio.isPlaying && Time.time > soundRate)
        {
            soundRate = Time.time + soundDelay;
            audio.clip = soundName;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }

    }

    private void PlaySound(AudioClip soundName, float soundDelay)
    {
        StartCoroutine(PlaySoundCorrutine(soundName, soundDelay));

    }
    /// <summary>
    /// The controlsof super mario
    /// </summary>
    private void Controls()
    {
        //declare flagsa


        if (controller.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            IdleAnimation();
            WalkAnimation();
            RunAnimation();
            CrouchAnimation();
            //modify the jump flags
            ControlJump();
        }
        else
        {
            ControlPostJump();
            //use the jump flags

        }

        CheckCurrentDirection();
        Move();


    }

    private void Move()
    {
        if(controller.collisionFlags == CollisionFlags.Above){
            velocity.y = 0;//stop the jump
            velocity.y -= afterHitForceDown; //starts going down
        }
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    /// <summary>
    /// Controls the jump animations and jumpo velocity
    /// </summary>
    private void JumpAnimation()
    {
        //in air move velocity in function of current action: run, walk or crouch
        if (jumpEnabled)
        {
            if (moveDirection == 1)
            {
                animator.SetColFrameStart(11).SetRowFrameStart(2).SetTotalFrames(4).SetFramesPerSecond(12);
            }
            else//left
            {
                animator.SetColFrameStart(11).SetRowFrameStart(3).SetTotalFrames(4).SetFramesPerSecond(12);
            }
            animator.Animate(gameObject, Time.time);

            velocity.x *= walkSpeed;
        }
        else if (runJumpEnabled)
        {
            if (moveDirection == 1)
            {
                animator.SetColFrameStart(11).SetRowFrameStart(2).SetTotalFrames(4).SetFramesPerSecond(12);
            }
            else//left
            {
                animator.SetColFrameStart(11).SetRowFrameStart(3).SetTotalFrames(4).SetFramesPerSecond(12);
            }
            animator.Animate(gameObject, Time.time);

            velocity.x *= runSpeed;
        }
        else if (crouchJumpEnabled)
        {
            if (moveDirection == 1)//right
            {
                animator.SetColFrameStart(12).SetRowFrameStart(10).SetTotalFrames(4).SetFramesPerSecond(12);
            }//left
            else
            {
                animator.SetColFrameStart(12).SetRowFrameStart(11).SetTotalFrames(4).SetFramesPerSecond(12);//left
            }
            animator.Animate(gameObject, Time.time);

            velocity.x *= walkSpeed;
        }


    }
    /// <summary>
    /// What to do after jumping: put the player again in the ground
    /// and perform several chekouts, allow the player movements in the air.
    /// It also selects the correct animation
    /// </summary>
    private void ControlPostJump()
    {
        velocity.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonUp("Jump"))
        {
            velocity.y -= fallSpeed;
        }

        JumpAnimation();

    }

    /// <summary>
    /// Choose the type of jump and mark the appropiate flag
    /// and jump velocity
    /// </summary>
    private void ControlJump()
    {
        //walk jump

        if (Input.GetButtonDown("Jump") && (!Input.GetButton("Fire1") || (Input.GetButton("Fire1") && velocity.x == 0)) && Input.GetAxis("Vertical") >= 0)
        {
            velocity.y = walkJump;
            Instantiate(particleJump,particlePlacement,transform.rotation);
            PlaySound(soundJump,0);
            jumpEnabled = true;
            runJumpEnabled = false;
            crouchJumpEnabled = false;
        }//run jump
        else if (Input.GetButtonDown("Jump") && Input.GetButton("Fire1") && velocity.x != 0)
        {
            velocity.y = runJump;
            Instantiate(particleJump, particlePlacement, transform.rotation);
            PlaySound(soundJump, 0);
            jumpEnabled = false;
            runJumpEnabled = true;
            crouchJumpEnabled = false;
        }//walk jump//crouch jump
        else if (Input.GetButton("Jump") && Input.GetAxis("Vertical") < 0 && velocity.x == 0)
        {
            velocity.y = crouchJump;
            PlaySound(soundCrouchJump, 0);
            Instantiate(particleJump, particlePlacement, transform.rotation);
            jumpEnabled = false;
            runJumpEnabled = false;
            crouchJumpEnabled = true;
        }
        else
        {
            jumpEnabled = false;
            runJumpEnabled = false;
            crouchJumpEnabled = false;
            stratPosition = transform.position; //this is for the camera to substract on zooming out
        }
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
            animator.SetColFrameStart(0).SetRowFrameStart(0).SetTotalFrames(16).SetFramesPerSecond(12);
            animator.Animate(gameObject, Time.time);
        }
        //idle left
        else if (velocity.x == 0 && moveDirection == 0)
        {
            animator.SetColFrameStart(0).SetRowFrameStart(1).SetTotalFrames(16).SetFramesPerSecond(12).SetRowSize(16);
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
                animator.SetColFrameStart(0).SetRowFrameStart(8).SetTotalFrames(16).SetFramesPerSecond(24);
                animator.Animate(gameObject, Time.time);
            }
            else //left
            {
                animator.SetColFrameStart(0).SetRowFrameStart(9).SetTotalFrames(16).SetFramesPerSecond(24);
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
            animator.SetColFrameStart(0).SetRowFrameStart(2).SetTotalFrames(10).SetFramesPerSecond(15);
            animator.Animate(gameObject, Time.time);
        }
        //walk left
        else if (velocity.x < 0 && !Input.GetButton("Fire1"))
        {
            velocity *= walkSpeed;
            animator.SetColFrameStart(0).SetRowFrameStart(3).SetTotalFrames(10).SetFramesPerSecond(15);
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
            animator.SetColFrameStart(0).SetRowFrameStart(4).SetTotalFrames(16).SetFramesPerSecond(24);
            animator.Animate(gameObject, Time.time);
        }
        //walk left
        else if (velocity.x < 0 && Input.GetButton("Fire1"))
        {
            velocity *= runSpeed;
            animator.SetColFrameStart(0).SetRowFrameStart(5).SetTotalFrames(16).SetFramesPerSecond(24);
            animator.Animate(gameObject, Time.time);
        }
    }




    void Start()
    {
        animator = CreateAnimator();
        controller = GetComponent<CharacterController>();
    }

    private AnimationSprite CreateAnimator()
    {
        int columnSize = 16;
        int rowSize = 16;
        int colFrameStart = 0;
        int rowFrameStart = 1;
        int totalFrames = 16;
        int framesPerSecond = 12;

        return new AnimationSprite(columnSize, rowSize, colFrameStart, rowFrameStart, totalFrames, framesPerSecond);

    }
}
