using UnityEngine;
using System.Collections;

public class ScriptEnemy : MonoBehaviour
{

    public int numberOfclicks = 2;
    private int restoreNMumberOfclicks;
    public float respawnWaitTime = 2.0F;
    public Color[] shapeColor;
    public Transform explosion;
    public int enemyPoint = 0;

    /// <summary>
    /// Method used for initialization
    /// </summary>
    void Start()
    {
        restoreNMumberOfclicks = numberOfclicks;
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (numberOfclicks <= 0)
        {
            if (explosion)
            {

                CreateExplosions();

            }
            var position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
            StartCoroutine(RespawnWaitTime());
            transform.position = position;
            numberOfclicks = restoreNMumberOfclicks;
        }
    }

    private void CreateExplosions()
    {
        Transform instance = (Transform)Instantiate(explosion, transform.position, transform.rotation);//Create an explosion at the same position and rotation than this object enemy
        //Como no hay  opcion autodestroy  que dice el video, decimos que elimine el objeto instanciado en 5s
        Destroy(instance.gameObject, 5);

    }
    private IEnumerator RespawnWaitTime()
    {
        renderer.enabled = false;
        RandomColor();
        yield return new WaitForSeconds(respawnWaitTime);
        renderer.enabled = true;

    }



    private void RandomColor()
    {
        if (shapeColor.Length > 0)
        {
            var newColor = Random.Range(0, shapeColor.Length);
            renderer.material.color = shapeColor[newColor];
        }

    }
}
