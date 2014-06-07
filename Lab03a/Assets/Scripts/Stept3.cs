using UnityEngine;
using System.Collections;

public class Stept3 : MonoBehaviour
{

    //inspector variables
    //number of tiles in the x row
    public int tileX;//u
    //number of tiles in the y row
    public int tileY;//v


    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(0.25F, 0F);

        Vector2 size = new Vector2(1.0F / tileX, 1.0F / tileY);
        renderer.material.mainTextureScale = size;
      
    }


}
