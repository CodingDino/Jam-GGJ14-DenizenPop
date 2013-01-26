using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	static public float horse_speed = 1.0f;		// Automatic speed
	static public float horse_movement = 1.5f;	// Player controlled speed
	static public float horse_jump = 4f;		// Jumping speed
	
	private bool on_platform = false;
	private bool has_double_jump = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// Move based on controls
		float moveX = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(moveX) > 0.1f)
		{
	        float moveDelta = horse_movement * Time.deltaTime;
	        transform.Translate(moveX * moveDelta, 0, 0, Space.World);
	    }
		
		// Jump - Only allow this when touching ground
		if (Input.GetButtonDown("Jump"))
		{
			if (!on_platform && has_double_jump)
			{
				has_double_jump = false;
        		rigidbody.velocity = new Vector3(0.0f,horse_jump,0.0f);
			}
			else if (on_platform)
			{
        		rigidbody.velocity = new Vector3(0.0f,horse_jump,0.0f);
			}
		}
		
		// Move based on horse speed
    	transform.Translate(Vector3.right * horse_speed * Time.deltaTime);
		Debug.Log ("translating");
	}
	
	// When colliding with the platform, set on_platform to true
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Platform")
		{
			on_platform = true;
			has_double_jump = true;
		}
    }
	
	// When leaving platform, set on_platform to false
    void OnCollisionExit(Collision collision) {
        if (collision.collider == GameObject.Find("Platform").collider)
			on_platform = false;
    }
}
