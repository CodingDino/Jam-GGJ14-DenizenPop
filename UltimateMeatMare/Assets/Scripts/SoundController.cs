using UnityEngine;
using System.Collections;

// Script sets audio volume relative to the distance between the player and the monster

public class SoundController : MonoBehaviour {
	
	public float maxDist = 6.7f;
	public float minDist = 3.0f;
	
	private MeatMonster pMonster = null;
	private PlayerMovement pHorse = null;
	public float distBetweenObjs = 0.0f;
	public float relVol = 0.0f;

	// Use this for initialization
	void Start () {
		//ref horse and monster
		pHorse = GameObject.Find("Horse").GetComponent<PlayerMovement>();
		pMonster = GameObject.Find("MeatMonster").GetComponent<MeatMonster>();
	}
	
	// Update is called once per frame
	void Update () {
		// set the volume relative to the horse
		distBetweenObjs = pHorse.transform.position.x - pMonster.transform.position.x;
		distBetweenObjs = distBetweenObjs-1.0f;
		relVol = 1.0f-distBetweenObjs;
		if(relVol > 0.0f)
		{
			gameObject.audio.volume = relVol;
		}else{
			gameObject.audio.volume = 0.0f;
		}
	}
}
