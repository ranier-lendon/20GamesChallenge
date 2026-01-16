using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private InputAction input;
    [SerializeField] private int speed = 10;
    private Vector2 move = Vector2.zero;
    
    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        move = input.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
        
        // Prevents paddle from goind out the screen
        float clampedY = Mathf.Clamp(rb.position.y, -3.35f, 3.35f);
        rb.position = new Vector2(rb.position.x, clampedY);
    }
}