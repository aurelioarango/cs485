using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ShooterGameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    //public GUIText scoreText;
    private int score;
    public Text countText;

    void Start()
    {
        score = 0;
        UpdateScore();
        Debug.Log("Start");
        StartCoroutine(SpawnWaves());

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
            
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliders");
        if (other.gameObject.CompareTag("Enemy"))
        {
            score =score +10 ;
            UpdateScore();
            Debug.LogWarning(countText);
        }
    }
  

    void UpdateScore()
    {
        countText.text = "Score: " + score.ToString();
    }
}

