using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titty_Gunner_AI : MonoBehaviour {
	private Vector2 original;
	private float t = 0.0f;
	private float min, max;
	public GameObject spawn;
	public GameObject projectile;
	public float speed;

	// Use this for initialization
	void Start() {
		original = transform.position;
		min = original.y - 1;
		max = original.y + 1;
	}
	
	// Update is called once per frame
	void Update() {
		GameObject player = GameObject.Find("Player");
		if(player != null) {
			if(player.transform.position.x > transform.position.x) transform.localScale = new Vector3(-1, 1, 0);
			else transform.localScale = new Vector3(1, 1, 0);

			float dist = Vector2.Distance(transform.position, player.transform.position);
			if(dist < 20) {
				transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 
					-(speed * Time.deltaTime));
				original = transform.position;
				min = original.y - 1;
				max = original.y + 1;
				t = 0.0f;
			} else if(dist < 50) {
				// create a new projectile
				Vector2 sp = spawn.transform.position;
				//float theta = Vector2.Angle(sp, player.transform.position) * Mathf.Deg2Rad;
				//projectile.GetComponent<Projectile_Script>().transform.position = sp;
				//projectile.GetComponent<Projectile_Script>().theta = theta;
				projectile.transform.Rotate(new Vector3(45.0f, 0, 0));
				Instantiate(projectile);
				projectile.transform.Rotate(new Vector3(-45.0f, 0, 0));
			} else {
				// bob up and down as in the HoverBob script
				transform.position = new Vector2(original.x, Mathf.Lerp(min, max, t));

				t += 0.5f * Time.deltaTime;
				if(t > 1.0f) {
					float temp = max;
					max = min;
					min = temp;
					t = 0.0f;
				}
			}
		}
	}
}
