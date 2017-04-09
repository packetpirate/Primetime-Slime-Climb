using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Tentacle : MonoBehaviour {
	private Vector2 tether;
    public Sprite tetherBlob;
	private bool canGrab;
	public float tetherSpeed;
    public float grabDistance;
	public float gravity;
    public float tetherWidth;
    private LineRenderer lineRenderer;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public float alpha = 1.0f;
    GameObject sprGameObj;

    // Use this for initialization
    void Start ()
    {
        tether = Vector2.zero;
        canGrab = true;
        SetLineRendererProperties();
    }

    // Update is called once per frame
    void Update () {
        if(tether != Vector2.zero)
        {
            DrawTether(GameObject.Find("Player"));
        }
		GameObject player = GameObject.Find("Player");
		if(player != null) {
			if(Input.GetMouseButtonDown(0) && canGrab) {
				Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
				Vector2 heading = target - playerPos;
				var distance = heading.magnitude;
				var dir = heading / distance;
				RaycastHit2D hit = Physics2D.Raycast(player.transform.position, dir, grabDistance, (1 << 9));
				if((hit != null) && (hit.transform != null)) {
					canGrab = false;
					tether = new Vector2(hit.transform.position.x, hit.transform.position.y);
                    PlaceBlobOnTetherPoint(tether);
					player.GetComponent<Rigidbody2D>().gravityScale = 0;
                    DrawTether(player);
                }
			} else if(Input.GetMouseButtonDown(1)) {
				canGrab = true;
				tether = Vector2.zero;
                // Destroy placed blob
                DestroyBlobOnTetherPoint(tether);
                player.GetComponent<Rigidbody2D>().gravityScale = gravity;
                // Clear the line renderer
                lineRenderer.positionCount = 0;
            }

			if(!canGrab && (tether != Vector2.zero)) {
				player.transform.position = Vector2.MoveTowards(player.transform.position, 
																tether, (tetherSpeed * Time.deltaTime));
			}
		}
	}

    private void PlaceBlobOnTetherPoint(Vector2 tether)
    {
        sprGameObj = new GameObject();
        sprGameObj.name = "tetherBlob";
        sprGameObj.AddComponent<SpriteRenderer>();
        SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
        sprRenderer.sprite = tetherBlob;
        sprRenderer.transform.localScale = new Vector3(5, 5);
        sprRenderer.transform.position = tether;
    }

    private void DestroyBlobOnTetherPoint(Vector2 tether)
    {
        var renderer = sprGameObj.GetComponent<SpriteRenderer>();
        renderer.sprite = null;
        sprGameObj = null;
    }

    private void DrawTether(GameObject slime)
    {
        Vector3[] lineEnds = new Vector3[2];

        lineEnds[0] = new Vector3(slime.transform.position.x, slime.transform.position.y);
        lineEnds[1] = new Vector3(tether.x, tether.y);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(lineEnds);
    }

    private void SetLineRendererProperties()
    {
        if(gameObject.GetComponent<LineRenderer>() != null)
        {
            lineRenderer = new LineRenderer();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = tetherWidth;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
    }
}
