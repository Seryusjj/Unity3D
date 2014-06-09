using UnityEngine;
using System.Collections;

public class KoalaBehaviour : MonoBehaviour
{

    private AnimationSprite animator;
    public enum Direction { Right, Left };
    public Direction currentDirection = Direction.Right;

    void Start()
    {
        animator = CreateAnimator();
    }


    private AnimationSprite CreateAnimator()
    {
        int columnSize = 8;
        int rowSize = 2;
        int colFrameStart = 2;
        int rowFrameStart = 0;
        int totalFrames=6;
        float framesPerSecond= 5;
        return new AnimationSprite(columnSize, rowSize, colFrameStart, rowFrameStart, totalFrames, framesPerSecond);
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        //IdleAnimation();
        WalkAnimation();
        //JumpAnimation();
    }




    private void IdleAnimation()
    {
        if (currentDirection == Direction.Right)
        {

            animator.SetColFrameStart(0).SetRowFrameStart(0).SetTotalFrames(2).SetFramesPerSecond(2);
            animator.Animate(gameObject, Time.time);
        }
        else if (currentDirection == Direction.Left)
        {
            animator.SetColFrameStart(0).SetRowFrameStart(1).SetTotalFrames(2).SetFramesPerSecond(2);
            animator.Animate(gameObject, Time.time);
        }
    }

    private void WalkAnimation()
    {
        if (currentDirection == Direction.Right)
        {

            animator.SetColFrameStart(2).SetRowFrameStart(0).SetTotalFrames(6).SetFramesPerSecond(5);
            animator.Animate(gameObject, Time.time);
        }
        else if (currentDirection == Direction.Left)
        {
            animator.SetColFrameStart(2).SetRowFrameStart(1).SetTotalFrames(6).SetFramesPerSecond(5);
            animator.Animate(gameObject, Time.time);
        }
    }

    private void JumpAnimation()
    {
        if (currentDirection == Direction.Right)
        {

            animator.SetColFrameStart(3).SetRowFrameStart(0).SetTotalFrames(3).SetFramesPerSecond(3);
            animator.Animate(gameObject, Time.time);
        }
        else if (currentDirection == Direction.Left)
        {
            animator.SetColFrameStart(3).SetRowFrameStart(1).SetTotalFrames(3).SetFramesPerSecond(3);
            animator.Animate(gameObject, Time.time);
        }
    }

    private void Controls()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            currentDirection = Direction.Left;
            Debug.Log("Going left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentDirection = Direction.Right;
            Debug.Log("Going right");
        }
    }
}
