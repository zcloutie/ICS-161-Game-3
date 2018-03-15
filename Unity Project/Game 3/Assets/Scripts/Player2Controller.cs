using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void Update()
    {
        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Death");
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