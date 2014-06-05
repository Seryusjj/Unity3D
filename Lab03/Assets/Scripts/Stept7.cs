using UnityEngine;
using System.Collections;

public class Stept7 : MonoBehaviour {

    //inspector variables


    public int columnSize;              //x (u) coordinate
    public int rowSize;                 //y (v) coordinate
    public float framesPerSecond = 12F;

    public int rowFrameStart = 0;
    public int colFrameStart = 0;
    public int totalFrames = 1;

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond);                //time control fpd
        //index = index % (columnSize * rowSize);                                 //modulate
        index = index % totalFrames; 

        Vector2 size = new Vector2(1.0F / columnSize, 1.0F / rowSize);          // scale

        int u = index % columnSize;
        int v = index / columnSize;

        //Vector2 offset = new Vector2(u * size.x, (1 - size.y) - (v * size.y));              //offset
        Vector2 offset = new Vector2((u + colFrameStart )* size.x, (1 - size.y) - ((v+rowFrameStart) * size.y));              //offset

        renderer.material.mainTextureOffset = offset;                   //texture offset
        renderer.material.mainTextureScale = size;                      //texture scale


    }
}
