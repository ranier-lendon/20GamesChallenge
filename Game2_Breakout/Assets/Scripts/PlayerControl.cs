using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 500f;
    private Vector2 move = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        move = new Vector2(horizontal, 0f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * Time.fixedDeltaTime * move;
        
        // Prevents player from getting out of screen
        float clampedX = Mathf.Clamp(rb.position.x, -7.9f, 7.9f);
        rb.position = new Vector2(clampedX, rb.position.y);
    }
}
