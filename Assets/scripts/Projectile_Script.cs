using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {
	public float theta;
	public float speed;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		var dx = Mathf.Cos(theta) * speed * Time.deltaTime;
		var dy = Mathf.Sin(theta) * speed * Time.deltaTime;

		transform.position = new Vector2((transform.position.x + dx), (transform.position.y + dy));
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			// reduce player size (damage the player)
		}
		Destroy(gameObject);
	}
}
