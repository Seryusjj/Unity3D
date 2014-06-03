using UnityEngine;
using System.Collections;

public class ScriptPlayer : MonoBehaviour
{

    //inspector variables
    public float playerSpeedVertical = 10.0F;
    public float playerSpeedHorizontal = 10.0F;
    public Transform proyectile;
    public Transform socketProyectile;

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

    void Update()
    {
        Controller();
        CreateBullet();
    }

    /// <summary>
    /// Shot to an enemy when pressing down the space bar
    /// </summary>
    private void CreateBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && proyectile!=null) {
            Instantiate(proyectile,socketProyectile.position,socketProyectile.rotation);
        }
    }


    private void Controller()
    {
        //la velocidad de movimiento ira siempre en funcion de la velocidad del ordenador sobre
        //el que se ejecuta el juego por eso usamos Time.deltaTime
        float transV = Input.GetAxis("Vertical")*playerSpeedVertical * Time.deltaTime;
        float transH= Input.GetAxis("Horizontal") * playerSpeedHorizontal * Time.deltaTime;
        transform.Translate(transH,transV,0);
        CheckLimits();
    }
    /// <summary>
    /// check the limits on a orthographic camera no matter wich resolution you use
    /// </summary>
    private void CheckLimits()
    {
        //si llegas al limite, la posicion de la figura será igual al limite.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -cameraWorldLimits.x, cameraWorldLimits.x), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -cameraWorldLimits.y, cameraWorldLimits.y), transform.position.z);

    }
}
