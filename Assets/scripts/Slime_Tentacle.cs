using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Tentacle : MonoBehaviour {
	private Vector2 tether;
	private bool canGrab;
	public float tetherSpeed;
	public float gravity;

	// Use this for initialization
	void Start () {
		tether = Vector2.zero;
		canGrab = true;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		if(player != null) {
			if(tether != Vector2.zero) Debug.DrawLine(player.transform.position, tether);
			if(Input.GetMouseButtonDown(0) && canGrab) {
				Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
				Vector2 heading = target - playerPos;
				var distance = heading.magnitude;
				var dir = heading / distance;
				RaycastHit2D hit = Physics2D.Raycast(player.transform.position, dir, 150.0f, (1 << 9));
				if((hit != null) && (hit.transform != null)) {
					canGrab = false;
					tether = new Vector2(hit.transform.position.x, hit.transform.position.y);
					player.GetComponent<Rigidbody2D>().gravityScale = 0;
				}
			} else if(Input.GetMouseButtonDown(1) && !canGrab) {
				canGrab = true;
				tether = Vector2.zero;
				player.GetComponent<Rigidbody2D>().gravityScale = gravity;
			}

			if(!canGrab && (tether != Vector2.zero)) {
				player.transform.position = Vector2.MoveTowards(player.transform.position, 
																tether, (tetherSpeed * Time.deltaTime));
			}
		}
	}
}
