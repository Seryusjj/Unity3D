using UnityEngine;
using System.Collections;

public class ScriptEnemy : MonoBehaviour {

    public  int numberOfclicks = 2;
    public float respawnWaitTime = 2.0F;
    

	

	void Update () {
        Move();
	}

    private void Move() {
        if (numberOfclicks <= 0)
        {
            Debug.Log("Move");
            var position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
            StartCoroutine(RespawnWaitTime());
            transform.position = position;
            numberOfclicks = 2;
        }
    }
    private IEnumerator RespawnWaitTime(){
        Debug.Log("RespawnWaitTime()");
        renderer.enabled = false;
        
        yield return new WaitForSeconds(respawnWaitTime);
        renderer.enabled = true;
        
    }


    private  void WaitForSeconds() {
        renderer.material.color = Color.red;
    }

    private void RandomColor() { 
    }
}
