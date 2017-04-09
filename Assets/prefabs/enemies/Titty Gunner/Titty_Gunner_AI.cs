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
    public int MaxDistanceX, MinDistanceX, MaxDistanceY, MinDistanceY;
    Vector3 initialPosition;
    float BobMinimum;
    float BobMaximum;
    private GameObject player;

    // Use this for initialization
    void Start() {
		original = transform.position;
		min = original.y - 1;
		max = original.y + 1;
        initialPosition = transform.position;
        BobMinimum = initialPosition.y - 2;
        BobMaximum = initialPosition.y + 2;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update() {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        if (player != null)
        {
            BobUpAndDown();
            if (player.transform.position.x < transform.position.x) spr.flipX = true;
            else spr.flipX = false;

            float distX = Mathf.Abs(transform.position.x - player.transform.position.x);
            float distY = Mathf.Abs(transform.position.y - player.transform.position.y);
            // Keep distance on X axis
            if ((distX > MaxDistanceX))
            {
                transform.position = Vector2.MoveTowards(transform.position,
                                                         new Vector2(player.transform.position.x, transform.position.y),
                                                         (speed * Time.deltaTime));
            }
            // Always try to be on the same horizontal level as the player.
            if(transform.position.y != player.transform.position.y + 1 && transform.position.y != player.transform.position.y - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, 
                                                            new Vector2(transform.position.x, player.transform.position.y), 
                                                            (speed * Time.deltaTime));
            }

        }
        /*if(player != null) {
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
				// create the projectile
				Vector3 sp = spawn.transform.position;
				Vector3 pl = player.transform.position;
				Vector3 dir = pl - sp;
				float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
				Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
				GameObject bullet = Instantiate(projectile, sp, rot);
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
		}*/
    }

    private void BobUpAndDown()
    {
        // Update is called once per frame
        // animate the position of the game object...
        transform.position = new Vector3(initialPosition.x, Mathf.Lerp(BobMinimum, BobMaximum, t), 0);

        // .. and increate the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = BobMaximum;
            BobMaximum = BobMinimum;
            BobMinimum = temp;
            t = 0.0f;
        }
    }
}
