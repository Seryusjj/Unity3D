using UnityEngine;
using System.Collections;

public class ScriptSceneManager : MonoBehaviour
{
    //inspector varibles
    public float gameTime = 60.0F;
    //public float labelRight = 75F; 



    //private variables
    private static int score;
    private static int lives = 3;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CountDown", 1.0F, 1.0F);
    }

    private void CountDown()
    {
        if (--gameTime <= 0)
        {

            CancelInvoke("CountDown");
        }
    }

    private void ResetGame()
    {
        lives = 3;
        PlayerPrefs.SetInt("SCORE", score);
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            Application.LoadLevel("sceneLose");
            ResetGame();

        }

        if (gameTime <= 0)
        {
            Application.LoadLevel("sceneWin");
            ResetGame();
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void SubstractLife()
    {
        lives--;
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
        GUI.Label(new Rect(10, 25, 100, 36), "Lives: " + lives);
        GUI.Label(new Rect(Screen.width - 75, 10, 100, 20), "Counter: " + gameTime);
    }

}
