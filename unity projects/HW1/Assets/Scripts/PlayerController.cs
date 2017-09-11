using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text result;
    private int count;
    void Start()
    {
        //looking for a rigid component 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        result.text = "";
    }

    void FixedUpdate()
    {
        //getting input from users
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertial = Input.GetAxis("Vertical");
        //adding force
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertial);
        rb.AddForce(movement  * speed);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            result.text = "You Win";
        }
    }
}
