using UnityEngine;
using System.Collections;

public class Stept5 : MonoBehaviour
{

    //inspector variables


    public int column;              //x (u) coordinate

    public int row;                 //y (v) coordinate

    public float framesPerSecond = 12F;

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond);                //time control fpd
        index = index % (column * row);                                 //modulate
        Vector2 size = new Vector2(1.0F / column, 1.0F / row);          // scale
        Vector2 offset = new Vector2(index * size.x, row);              //offset

        renderer.material.mainTextureOffset = offset;                   //texture offset
        renderer.material.mainTextureScale = size;                      //texture scale


    }
}
