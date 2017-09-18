using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    //private int score;
    //private Text scoreText;

   /* void Start()
    {
        score = 0;
       // UpdateScore();
        //scoreText.text = "";
    }
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            //score = score + 10;
            //Debug.LogWarning("Player", explosion);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);


       /* if (other.gameObject.CompareTag("Bolt") )
        {
            //score = score + 10;
            Debug.LogWarning("Bolt", explosion);
            //UpdateScore();

        }*/
       
        
    }
   
    /*void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }*/


}

