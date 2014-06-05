using UnityEngine;
using System.Collections;

public class ScriptShield : MonoBehaviour
{
    //inspector variables
    public int shieldStregth = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyShield();
    }

    /// <summary>
    /// Method call by unity when a trigger is shot,
    /// in this case whe hace an sphere collider (the shield) wich is the  trigger
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag.Equals("asteroid"))
        {
            shieldStregth--;
        }

    }



    private void DestroyShield(){
        if(shieldStregth<=0){
            Destroy(gameObject);
            transform.parent.GetComponent<ScriptPlayer>().shieldOn = false;
            
        }
    }
}
