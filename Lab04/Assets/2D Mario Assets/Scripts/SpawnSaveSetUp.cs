using UnityEngine;
using System.Collections;

public class SpawnSaveSetUp : MonoBehaviour {

    public Transform startPoint;//where the plyer should start nex time
    public AudioClip soundDie;

    private  float soundRate = 0F; //hold current time + delay amount
    //private float soundRate = 0F; //amount time to dalay before play the sound again
    private Vector3 currentSavePosition; //current save position of the player


    private IEnumerator PlaySoundCorrutine(AudioClip soundName, float soundDelay)
    {
        if (!audio.isPlaying && Time.time > soundRate)
        {
            soundRate = Time.time + soundDelay;
            audio.clip = soundName;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }

    }

    private void PlaySound(AudioClip soundName, float soundDelay)
    {
        StartCoroutine(PlaySoundCorrutine(soundName, soundDelay));

    }

	// Use this for initialization
	void Start () {
        if (startPoint != null)
        {
            this.transform.position = startPoint.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// when marrio colides with somethin that is a ssavePoint 
    /// then next time is going to restart from ther
    /// and if collide with a killbox, then move mario to the last hitted savePoint
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("savePoint")){
            currentSavePosition = this.transform.position;
        }
        if (other.tag.Equals("killbox"))
        {
            PlaySound(soundDie,0);
            transform.position = currentSavePosition;
        }
    }
}
