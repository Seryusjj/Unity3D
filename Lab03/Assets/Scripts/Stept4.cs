using UnityEngine;
using System.Collections;

public class Stept4 : MonoBehaviour {

    //inspector variables

    //number of tiles in the x row
    public int column;//u
    //number of tiles in the y row
    public int row;//v

    public int index = 1;

    void Update()
    {

        index = index % (column * row);//modulate
        Vector2 size = new Vector2(1.0F / column, 1.0F / row);// scale
        Vector2 offset = new Vector2(index * size.x,row);//offset

        renderer.material.mainTextureOffset = offset; //texture offset
        renderer.material.mainTextureScale = size;//texture scale
        
     
    }
}
