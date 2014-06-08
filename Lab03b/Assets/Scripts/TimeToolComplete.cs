using UnityEngine;
using System.Collections;

public class TimeToolComplete : MonoBehaviour
{

    public GameObject aniFont1;
    public GameObject aniFont2;
    public GameObject aniFont3;
    public GameObject aniFont4;

    public GUISkin marioGui;

    private float playTime;


    private AnimationSprite animator;
    void Start()
    {
        animator = new AnimationSprite(10/*tiles per row*/, 1/*rowSize*/, 0/*colFrameStart*/, 0/*rowFrameStart*/, 10/*total frames in all columns*/, 1/*frames per second*/);

    }


    void Update()
    {
        playTime = Time.time;
        animator.AnimateFont(aniFont1,playTime,"font1");
        animator.AnimateFont(aniFont2, playTime, "font2");
        animator.AnimateFont(aniFont3, playTime, "font3");
        animator.AnimateFont(aniFont4, playTime, "font4");
    }


    void OnGUI()
    {
        GUI.skin = marioGui;
        GUI.Label(new Rect(Screen.width / 2, 10, 1000, 100), "" + playTime.ToString("0.0"));
    }





}
