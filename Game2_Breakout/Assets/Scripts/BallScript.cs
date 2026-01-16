using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float angle = 0f;
    private int xDirection = -1;
    private float speed = 300f;
    private int yDirection = -1;
    private Vector2 move = Vector2.zero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            yDirection *= -1;
            
            float normalize = collision.transform.position.x - transform.position.x;
            angle = normalize * speed * 1.8f;

            if (normalize > 1)
            {
                xDirection *= -1;
                Debug.Log(normalize);
            }
        }
        
        if (collision.gameObject.tag == "Ceiling")
        {
            yDirection *= -1;
        }

        if (collision.gameObject.tag == "Wall")
        {
            xDirection *= -1;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = new Vector2(angle * xDirection, speed * yDirection);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Time.fixedDeltaTime * move;
    }
}
