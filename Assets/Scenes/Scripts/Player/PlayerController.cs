using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;

    private Rigidbody2D rb2d;
    private Vector2 movement;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (movement != Vector2.zero)
        {
            FacingDirection = movement.normalized;
            UpdateSpriteDirection();
        }

    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = movement * speed;
    }

    void UpdateSpriteDirection()
{
    if (FacingDirection.y > 0.5f)
        spriteRenderer.sprite = spriteUp;
    else if (FacingDirection.y < -0.5f)
        spriteRenderer.sprite = spriteDown;
    else if (FacingDirection.x < -0.5f)
        spriteRenderer.sprite = spriteLeft;
    else if (FacingDirection.x > 0.5f)
        spriteRenderer.sprite = spriteRight;
}

}

