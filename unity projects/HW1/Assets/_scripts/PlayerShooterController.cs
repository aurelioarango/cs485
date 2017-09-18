using System.Collections;

using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax,  yMin,yMax;
}

public class PlayerShooterController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource audiosource;
    public int speed;
    public float tilt;
    public Boundary boundary;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Start()
    {
        //looking for a rigid component 
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audiosource.Play();
        }

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

       rb.position = new Vector3
       (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f

       );
         //rb.rotation = Quaternion.Euler(0.0f, rb.velocity.y * - tilt, 0.0f);
        // rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt, 0.0f, rb.velocity.x * -tilt);

    }
}

