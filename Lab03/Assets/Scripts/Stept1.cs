using UnityEngine;
using System.Collections;

/// <summary>
/// this script allow show how to scroll a 
/// texture that is applied to a plane
/// </summary>
public class Stept1 :MonoBehaviour
{
    public float scrollSpeed = 0.1F;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        //desplaza el offset de x en funcion de la velocidad indicada 
        //deja inmovil el offset y pues pretndemos un scroll lateral
        renderer.material.mainTextureOffset = new Vector2(offset, 0);

    }
}
