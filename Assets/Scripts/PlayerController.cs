/*
 *  Sets up a Controller for the player in the game
 *  Dean Brown 21/07/2015
 */ 

using UnityEngine;
using System.Collections;
// Use the UI toolset
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // Variables
    private Rigidbody rb;
    private float jumpHeight = 250f;
    private int count;
    private bool isFalling = false;
    public float speed = 100f;

    // UI Variables
    public Text countText;
    public Text winText;

    void setCountText()
    {
        // Update the text box everytime we collect a new cube
        countText.text = "Count: " + count.ToString();

        if (count == 10)
        {
            winText.text = "You Win!";
        }
    }

    // Called on the first frame the script is active for
    void Start()
    {
        count = 0;
        // Initialize the count text
        setCountText();
        winText.text = "";
        rb = GetComponent<Rigidbody>();
    }
    // Called before rendering a frame
    void Update()
    {
        
    }

    // Called before performing physics calculations
    void FixedUpdate()
    {
        // Gets the input in the Horizontal and Vertical axis returned as -1 .. 1
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        // Create a new vector3
        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        // Pass the vector3 the movement variable
        rb.AddForce(movement * speed);

        // Add jump functionality
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)
        {
            Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
            rb.AddForce(jump);
        }
    }

    // Handle collision
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Collectable"))
        {
            otherObject.gameObject.SetActive(false);
            count++;
            // Update the count text
            setCountText();
            
        }
    }
	
}
