using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShooterGameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText backText;

    private int score;

    private bool gameOver;
    private bool restart;
    private bool back;
    

    void Start()
    {
        gameOver = false;
        restart = false;
        back = true;
        restartText.text = "";
        gameOverText.text = "";
        backText.text = "Press 'B' for Back";

        score = 0;
        UpdateScore();
        //Debug.Log("Start");
        StartCoroutine(SpawnWaves());

    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(2 );
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
        if(back)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                SceneManager.LoadScene(0);
            }
           
        }
    }

    IEnumerator SpawnWaves()
    {
        //Debug.Log("Before True");
        yield return new WaitForSeconds(startWait);
        while (true)

        {
            //Debug.Log("True");

            for (int i = 0; i < hazardCount; i++)
            {
            
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y) , spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            
           
           

        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}

