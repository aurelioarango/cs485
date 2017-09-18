using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int score;
    public Text scoreText;

    private ShooterGameController shootergamecontroller;

    void Start()
     {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            shootergamecontroller = gameControllerObject.GetComponent<ShooterGameController>();
        }
        if (shootergamecontroller == null)
        {
            Debug.Log("Cannot find 'ShooterGameController' script");
        }
    }
     
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
            shootergamecontroller.GameOver();
        }
        

        if (other.gameObject.CompareTag("Bolt") )
        {
  
            Debug.LogWarning("Bolt", explosion);
            shootergamecontroller.AddScore(score);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);

    }


}

