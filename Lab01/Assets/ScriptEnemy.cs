using UnityEngine;
using System.Collections;

public class ScriptEnemy : MonoBehaviour {

    public  int numberOfclicks = 2;
    public float respawnWaitTime = 2.0F;
    public Color[] shapeColor;
    

	

	void Update () {
        Move();
	}

    private void Move() {
        if (numberOfclicks <= 0)
        {
            var position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
            StartCoroutine(RespawnWaitTime());
            transform.position = position;
            numberOfclicks = 2;
        }
    }
    private IEnumerator RespawnWaitTime(){
        renderer.enabled = false;
        RandomColor();
        yield return new WaitForSeconds(respawnWaitTime);
        renderer.enabled = true;
        
    }



    private void RandomColor() {
        if (shapeColor.Length > 0)
        {
            var newColor = Random.Range(0, shapeColor.Length);
            renderer.material.color = shapeColor[newColor];
        }

    }
}
