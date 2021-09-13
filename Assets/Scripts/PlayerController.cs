using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    

    private Rigidbody rb;
    public Text countText;
    public Text livesText;
    public Text winText;
    public Text loseText;
    private int count;
    private int lives;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();
        SetCountText();
        SetLivesText();
        
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
       else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();

        }
                
       
       
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16)
        {
            winText.text = "You're Winner!, Made By Brendan St.Esprit";
        }
        if (count >= 10)
        {
            transform.position = new Vector3(-8.65f, 15.3f, 96.7f); 
        }

    }
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {

            loseText.text = "Sorry, You lost everyting";
            SetLivesText();
            
        }
    }
    void DestroyScriptInstance()
    {
        if (lives == 0)
        {
            Destroy(this);
        }
    }

}
