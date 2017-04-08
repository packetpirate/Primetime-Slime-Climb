using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Sucker_AI : MonoBehaviour {
	private BoxCollider2D bc;
	public GameObject player;

	// Use this for initialization
	void Start() {
		bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}
}
