using UnityEngine;
using System.Collections;

public class ScriptAsteroid : MonoBehaviour
{
    //inspector variables
    public float asteroidSpeed = 6.0F;
    //private variables
    private Vector3 cameraWorldLimits;
    // Use this for initialization
    void Start()
    {
        CalculateLimits();
    }
    /// <summary>
    /// Calculate the game limits, call on Startupbecause just need to calculate it once
    /// </summary>
    private void CalculateLimits()
    {
        //obtenemos el ancho alto y profunidad de lo que ve la camara en puntos del mundo
        cameraWorldLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Screen.dpi));
        //obtenemos la caja que rodea la figura si es una esfera nos da el diametro y queremos el radio, lo mismo para un cubo
        Mesh cubeMesh = GetComponent<MeshFilter>().mesh;
        Vector3 objectSice = cubeMesh.bounds.size / 2;
        cameraWorldLimits = new Vector3(cameraWorldLimits.x - objectSice.x, cameraWorldLimits.y - objectSice.y, cameraWorldLimits.z - objectSice.z);

    }
    // Update is called once per frame
    void Update()
    {
        float newSpeed = asteroidSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * newSpeed);
        RepositionateAsteroid();
    }

    /// <summary>
    /// check the limits on a orthographic camera no matter wich resolution you use
    /// </summary>
    private void RepositionateAsteroid()
    {

        //si llegas al limite, vuele a subir
        if (transform.position.y < -cameraWorldLimits.y)
        {
            RandomMove();
        }

    }

    public void RandomMove() {
        transform.position = new Vector3(Random.Range(-cameraWorldLimits.x - 1, cameraWorldLimits.x - 1), cameraWorldLimits.y + 1, transform.position.z);
    }


}
