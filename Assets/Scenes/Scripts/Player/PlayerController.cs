using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WeaponData staff;
    [SerializeField] private WeaponData sword;
    private static PlayerController instance;
    public float speed = 5f;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private CharacterAnimator characterAnimator;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        rb2d = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        movement = movement.normalized;
        if (movement != Vector2.zero)
            FacingDirection = movement;

        if (Input.GetButtonDown("Fire1"))
            GetComponent<PlayerCombat>().TryAttack();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            GetComponent<PlayerCombat>().TryEquip(staff);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GetComponent<PlayerCombat>().TryEquip(sword);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        //movement = movement.normalized;

        characterAnimator.UpdateAnimation(movement);
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = movement * speed;
    }

    public static void TeleportTo(Vector3 position)
    {
        //for MazeNode
        if (instance == null)
        {
            Debug.LogError("Player instance not found!");
            return;
        }

        instance.transform.position = position;
    }

}