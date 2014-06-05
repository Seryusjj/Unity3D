using UnityEngine;
using System.Collections;

public class ScritBullet : MonoBehaviour
{
    //inspector ariables
    public float bulletSpeed = 15.0F;
    public Transform explosion;
    public GameObject sceneManager;
    public AudioClip audioclip;

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
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
        DestroyBullet();
    }



    /// <summary>
    /// check the limits on a orthographic camera no matter wich resolution you use
    /// </summary>
    private void DestroyBullet()
    {
        //si llegas al limite, se destruye el objeto
        if (transform.position.y > cameraWorldLimits.y)
        {
            Destroy(gameObject);
        }


    }

    /// <summary>
    /// Method call by unity when a trigger is shot,
    /// in this case whe hace an sphere collider wich is the  trigger
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("asteroid"))
        {
            other.GetComponent<ScriptAsteroid>().RandomMove();

            if (explosion) {
                Instantiate(explosion, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(audioclip,transform.position);
            }
            //tell the scene manager that we destroyed an enemy and add a point to the score
            sceneManager.transform.GetComponent<ScriptSceneManager>().AddScore();

            //consume the bullet
            Destroy(gameObject);
        }


    }


}
