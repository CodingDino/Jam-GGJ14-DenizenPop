using UnityEngine;
using System.Collections;

public class OnionScript : MonoBehaviour {
	
	private MeatMonster refMeatMonster = null;
	
	// Use this for initialization
	void Start () {
		refMeatMonster = GameObject.Find("MeatMonster").GetComponent<MeatMonster>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider tCollider)
	{
		if(tCollider.gameObject.name == "Horse" && refMeatMonster != null)
		{
			// speed up the Meat Monster
			refMeatMonster.OnionBoost();
			Debug.Log("Onion Collected!");
			Destroy(this.gameObject);
		}
	}
}
