using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement;
    public float speed = 5f;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;
    private Rigidbody2D rb2d;
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            FacingDirection = movement.normalized;
        }

        movement = movement.normalized;
    }



    void FixedUpdate()
        {
            rb2d.linearVelocity = movement * speed;
        }

}
