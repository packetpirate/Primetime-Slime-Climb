using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		transform.position += transform.right * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			// reduce player size (damage the player)
		}
		Destroy(gameObject);
	}
}
