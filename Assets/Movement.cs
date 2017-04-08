using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 20.0f;
        var newPosition = new Vector2(rb.transform.position.x + x, rb.transform.position.y);
        rb.MovePosition(newPosition);

        var hit = new RaycastHit();

        if (Physics.Raycast(transform.position, Vector3.down))
        {
            if (hit.collider.attachedRigidbody == GetComponent<Floor>()) //the players .gameObject is there because i'm not sure if you have it set to a transform, if it's a GameObject then you can be rid of it :)
            {
                GetComponent<HappySlimeFace>().SetOrderToOne();
                GetComponent<SurprisedSlimeFace>().SetOrderToZero();
                Debug.Log("Raycast hit lower Object");
            }
            else
            {
                GetComponent<SurprisedSlimeFace>().SetOrderToOne();
                GetComponent<HappySlimeFace>().SetOrderToZero();
                Debug.Log("Didn't hit anything.");
            }
        }
    }

    public Vector2 GetPosition()
    {
        return new Vector2();
    }
}
