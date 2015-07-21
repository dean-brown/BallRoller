/*
 *  Manages the camera
 */ 
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    // Create a variable to hold a ref to the player and to hold a vector
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
	    // Set up the location of the camera
        offset = transform.position - player.transform.position;
	}

    // Update is called once per frame
    void Update()
    {


    }

    // Runs every frame but after update. (So we know the player has moved)
    void LateUpdate()
    {
        transform.position = player.transform.position +    offset;
    }
	
	
}
