using UnityEngine;
using System.Collections;

public class BBQJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider tCollider)
	{
		if(tCollider.gameObject.name == "Barbeque")
		{
			// make the damn horse jump
			//FireJump();
		}
	}
}
