using UnityEngine;
using System.Collections;

public class CarrotScript : MonoBehaviour {
	
	public PlayerMovement horse = null;
	
	// Use this for initialization
	void Start () {
		horse = GameObject.Find("Horse").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider tCollider)
	{
		if(tCollider.gameObject.name == "Horse")
		{
			// speed up the horse
			horse.CarrotBoost();
			Debug.Log("Carrot Collected!");
			Destroy(this.gameObject);
		}
	}
}
