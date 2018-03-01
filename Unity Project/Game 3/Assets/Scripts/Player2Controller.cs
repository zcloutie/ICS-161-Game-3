﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        float moveVertical = Input.GetAxis("Vertical2");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        /*rb.position = new Vector2 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (rb.position.y, boundary.zMin, boundary.zMax)
			);

		//rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);*/
    }
}