using UnityEngine;
using System.Collections;

public class AnimationSprite : MonoBehaviour
{

    public void Animate(int columnSize, int rowSize, int colFrameStart, int rowFrameStart, int totalFrames, float framesPerSecond)
    {
        int index = (int)(Time.time * framesPerSecond);                //time control fpd
        //index = index % (columnSize * rowSize);                                 //modulate
        index = index % totalFrames;

        Vector2 size = new Vector2(1.0F / columnSize, 1.0F / rowSize);          // scale

        int u = index % columnSize;
        int v = index / columnSize;

        //Vector2 offset = new Vector2(u * size.x, (1 - size.y) - (v * size.y));              //offset
        Vector2 offset = new Vector2((u + colFrameStart) * size.x, (1 - size.y) - ((v + rowFrameStart) * size.y));              //offset

        renderer.material.mainTextureOffset = offset;                   //texture offset
        renderer.material.mainTextureScale = size;                      //texture scale

        renderer.material.SetTextureOffset("_BumpMap", offset);
        renderer.material.SetTextureScale("_BumpMap", size);
    }
}
