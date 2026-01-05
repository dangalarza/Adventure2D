using UnityEngine;
using System.Collections;

public class HoodController : Enemy
{
    public float detectionRange = 4f;
    //public int maxHealth = 3;
    //override protected int currentHealth;
    private Transform player;
    //private Rigidbody2D rb;
    //private Enemy enemy;
    //new private HoodAnimator animator;
    private HoodLogic logic;
    private bool active;
    //public bool IsDead {get; private set;}
    //public bool IsStunned {get; private set;}


    new void Awake()
    {
        currentHealth = maxHealth;
        logic =  GetComponent<HoodLogic>();
        //rb = GetComponent<Rigidbody2D>();
        //enemy = GetComponent<Enemy>();
        //Hanimator  = GetComponent<HoodAnimator>(); 
        animator = GetComponent<HoodAnimator>();
        contactDamage = 0;
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > detectionRange)
        {
            active = false;
            if (distance > detectionRange + 2f) GetComponent<HoodAnimator>().SetInactive();
        }
        else
        {
            active = true;
            GetComponent<HoodAnimator>().SetActive();
        }
        logic.SetTargetDistance(distance);
        logic.SetActive(active);
        
    }

    public override void TakeDamage(int amount, Vector2 attackerPosition)
    {
        currentHealth -= amount;
        if (animator != null && currentHealth > 0)
        {
           animator.PlayHurt();
        }

        ApplyKnockback(attackerPosition, .2f, .4f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

}
