using UnityEngine;
using System.Collections;

public class FoalScript : MonoBehaviour {
	
	private PlayerMovement pHorse = null;
	
	// Use this for initialization
	void Start () {
		pHorse = GameObject.Find("Horse").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider tCollider)
	{
		if(tCollider.gameObject.name == "Horse")
		{
			// add something to the score!
			pHorse.FoalCollect();
			Debug.Log("Foal Collected!");
			Destroy(this.gameObject);
		}
	}
}
