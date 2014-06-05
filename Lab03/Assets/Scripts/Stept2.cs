using UnityEngine;
using System.Collections;
/// <summary>
/// Scale a texture over a plane in order to fit it inside even if its an spreat sheet animation
/// </summary>
public class Stept2 : MonoBehaviour {

	//inspector variables

	
	// Update is called once per frame
	void Update () {
        renderer.material.mainTextureOffset = new Vector2(0.25F,0F);
        renderer.material.mainTextureScale = new Vector2(0.0625F, 1F);
	}


}
