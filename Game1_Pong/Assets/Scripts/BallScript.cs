using System;
using UnityEngine;
using Random = System.Random;

public class BallScript : MonoBehaviour
{
    private Random rand = new();
    private Rigidbody2D rb;
    [SerializeField] private float speedX = 200f;
    private float xDirection = 1f;
    [SerializeField] private float speedY = 100f;
    private float yDirection = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if collided to player
        if (collision.gameObject.tag == "Player")
        {
            // Increase speed then flips the x movement of ball
            speedX += 25f;
            xDirection *= -1;
            
            // Randomly change angle and direction of the ball
            speedY =  speedX * (float) Math.Clamp(rand.NextDouble(), 0.2, 0.9);
            yDirection = Mathf.Sign(rand.Next(-1, 1));
        }

        // Checks if collided with a wall/border
        if (collision.gameObject.tag == "Wall")
        {
            yDirection *= -1;
        }
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Randomly decide the x/y direction and angle of the ball.
        xDirection *= -1;
        speedY =  speedX * (float) Math.Clamp(rand.NextDouble(), 0.2, 0.8);
        yDirection = Mathf.Sign(rand.Next(-1, 1));
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = Time.fixedDeltaTime * speedX * xDirection * Vector2.right.x;
        rb.linearVelocityY = Time.fixedDeltaTime * speedY * yDirection * Vector2.up.y;
    }
}
