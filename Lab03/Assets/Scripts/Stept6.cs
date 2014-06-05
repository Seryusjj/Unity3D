using UnityEngine;
using System.Collections;

public class Stept6 : MonoBehaviour {

    //inspector variables


    public int column;              //x (u) coordinate

    public int row;                 //y (v) coordinate

    public float framesPerSecond = 12F;

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond);                //time control fpd
        index = index % (column * row);                                 //modulate
        
        Vector2 size = new Vector2(1.0F / column, 1.0F / row);          // scale

        int u = index % column;
        int v = index / column;

        Vector2 offset = new Vector2(u * size.x, (1-size.y)-(v*size.y));              //offset

        renderer.material.mainTextureOffset = offset;                   //texture offset
        renderer.material.mainTextureScale = size;                      //texture scale


    }
}
