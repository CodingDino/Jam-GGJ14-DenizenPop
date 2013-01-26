using UnityEngine;
using System.Collections;

public class MeatMonster : MonoBehaviour {

	private bool isBoosting = false;
	private float currentSpeed = 0;
	private int boostCount = 0;
	private float accel = 0.00167f;
	
	// Use this for initialization
	void Start () {
		currentSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// Base acceleration
		currentSpeed += accel;
		
		// Move based on currentSpeed
    	transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
		
		// check for slowdown
		if(isBoosting)
		{
			boostCount++;
			if(boostCount > 180)
			{
				//stop boosting
				isBoosting = false;
				currentSpeed -=0.5f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void OnionBoost()
	{
		// speed up temporarily
		if(!isBoosting)
		{
			isBoosting = true;
			boostCount = 0;
			currentSpeed+=0.5f;
		}
	}
	
	void OnTriggerEnter(Collider tCollider)
	{
		if(tCollider.gameObject.name == "Horse")
		{
			// GAME OVER, MAN!
			//tCollider.gameObject.GetComponent("HorseMovement").GameOver();
			Debug.Log ("Game over, man, it's game over!");
		}
	}
}