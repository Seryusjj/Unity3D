using UnityEngine;
using System.Collections;

public class Stept10 : MonoBehaviour
{



    void Update()
    {
        AnimationSprite aniPlay = transform.GetComponent<AnimationSprite>();
        if (Input.GetKey(KeyCode.D))
        {
            aniPlay.Animate(8, 2, 0, 0, 16, 12);
        }
    }


}
