﻿using System.Collections;
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
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 20.0f;

        var newPosition = new Vector2(rb.transform.position.x + x, rb.transform.position.y + y);
        rb.MovePosition(newPosition);
    }
}
