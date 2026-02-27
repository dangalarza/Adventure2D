using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WeaponData staff;
    [SerializeField] private WeaponData sword;
    private static PlayerController instance;
    public float speed = 5f;
    public float fallduration = .5f;
    private bool isFalling = false;
    private bool canMove = true;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;
    public bool isDead = false;
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
        if (canMove && !isDead)
        {
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

            characterAnimator.UpdateAnimation(movement);
        }
        else if (isDead)
        {
            characterAnimator.UpdateAnimation("Dead");
        }
        

    }

    void FixedUpdate()
    {
        if(isDead) rb2d.linearVelocity = movement * 0f;
        else if (canMove) rb2d.linearVelocity = movement * speed;
        else         rb2d.linearVelocity = movement * 0f;
    }

    public static void TeleportTo(Vector3 position)
    {
        //for MazeNode, teleports player
        if (instance == null)
        {
            Debug.LogError("Player instance not found!");
            return;
        }

        instance.transform.position = position;
    }

    public static Transform Transform
    {
        get
        {
            if (instance == null) return null;
            return instance.transform;
        }
    }


    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;
    }

    public void SetDeath(bool dead)
    {
        isDead =  dead;
    }

    public IEnumerator FallDownPit(Vector3 target)
    {
        GetComponent<PlayerHealth>().TakeDamage(1, transform.position);
        isFalling =  true;
        Vector2 lastMovement = FacingDirection;
        SetMovementEnabled(false);
        Vector2 originalScale = transform.localScale;
        float elapsed = 0f;
        while (elapsed < fallduration)
        {
            float t = elapsed/fallduration;
            transform.position += (Vector3)(rb2d.linearVelocity.normalized * .1f);
            transform.localScale = Vector3.Lerp(originalScale, originalScale/3, t);
            yield return null;
            elapsed += Time.deltaTime;
        }
        TeleportTo(target);
        transform.localScale = originalScale;
        SetMovementEnabled(true);
        isFalling = false;
        
    }
}