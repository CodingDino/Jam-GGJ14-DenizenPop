using UnityEngine;
using System.Collections;

public class PlatformRespawn : MonoBehaviour {
	
	GameObject horse_reference = null;
	private float despawn_offset = 3;
	private float respawn_offset = 5;
	private float y_spawn_range = 1.0f;

	// Use this for initialization
	void Start () {
		horse_reference = GameObject.Find("Horse");
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.isVisible && transform.position.x < horse_reference.transform.position.x-despawn_offset)
			RespawnPlatform(y_spawn_range);
	}
	
	void RespawnPlatform(float y_spawn_range)
	{
		//float moveY = y_spawn_range /2 - Random.value*y_spawn_range;
		float moveY = 0;
		transform.Translate(despawn_offset+respawn_offset, moveY, 0, Space.World);
	}
	
	// On Collision Enter
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Platform")
		{
			RespawnPlatform(0);
		}
    }
}
