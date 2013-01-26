using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private float horse_speed = 1.0f;		// Automatic speed
	private float horse_movement = 1.5f;	// Player controlled speed
	private float horse_jump = 4f;			// Jumping speed
	private float horse_accel = 0.002f;		// Acceleration over time
	
	private bool on_platform = false;
	
	private int jump_count = 2;
	
	private int score = 0;
	
	private float fall_death_value = -2.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// Base acceleration
		horse_speed += horse_accel;
		
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
			
			if (jump_count > 0)
			{
        		rigidbody.velocity = new Vector3(0.0f,horse_jump,0.0f);
				--jump_count;
			}
		}
		
		// Move based on horse speed
    	transform.Translate(Vector3.right * horse_speed * Time.deltaTime);
		score += 1;
		
		// Check if fell off bottom of screen
		// If below cut off y value...
		if(transform.position.y < fall_death_value)
		{
			// GAME OVER, MAN!
			Debug.Log ("Game over, man, it's game over!");
			//GameOver();
			// Freeze camera (part of GameOver?)
			transform.DetachChildren();
			// Display game over message
		}
	}
	
	// On Collision Enter
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Platform")
		{
			on_platform = true;
			
			// If the platform is below the horse
			var relativePosition = collision.contacts[0].normal;
			if (relativePosition.y > 0)
				jump_count = 2;
		}
    }
	
	// On Trigger Enter
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "Barbeque")
		{
			// make the horse bounce!
        	rigidbody.velocity = new Vector3(0.0f,horse_jump,0.0f);
			jump_count = 0;
		}
    }
	
	// On Collision Exit
    void OnCollisionExit(Collision collision) {
        if (collision.collider == GameObject.Find("Platform").collider)
		{
			on_platform = false;
		}
    }
	
	// On Trigger Exit
    void OnTriggerExit(Collider collider) {
    }
	
	// Called when hit by a hedge
	public void OnHedgeHit()
	{
		// slow the damn horse down
		horse_speed -= 0.5f;
	}
	
	public void CarrotBoost()
	{
		horse_speed += 0.5f;
	}
	
	public void FoalCollect()
	{
		score += 100;
	}
	
	public int GetScore()
	{
		return score;
	}
	
}
