using UnityEngine;
using System.Collections;

public class KoalaBehaviour : MonoBehaviour
{

    private AnimationSprite animator;
    void Start()
    {
        animator = CreateAnimator();
    }


    private AnimationSprite CreateAnimator()
    {
        int columnSize = 5;
        int rowSize = 1;
        int colFrameStart = 1;
        int rowFrameStart = 0;
        int totalFrames=4;
        float framesPerSecond= 4;
        return new AnimationSprite(columnSize, rowSize, colFrameStart, rowFrameStart, totalFrames, framesPerSecond);
    }

    // Update is called once per frame
    void Update()
    {
        animator.Animate(gameObject, Time.time);
    }
}
