using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Sucker_AI : MonoBehaviour {
	private BoxCollider2D bc;
	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start() {
		bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update() {
		var dv = player.transform.position - transform.position;
		var dist = Mathf.Sqrt((dv.x * dv.x) + (dv.y * dv.y));
		if(dist < 20.0) {
			transform.position = Vector2.Lerp(transform.position, player.transform.position, (speed * Time.deltaTime));
		}
	}
}
