using UnityEngine;
using System.Collections;

public class HoodController : Enemy
{
    public float detectionRange = 4f;
    private Transform player;
    private HoodLogic logic;
    private bool active;


    new void Awake()
    {
        currentHealth = maxHealth;
        logic =  GetComponent<HoodLogic>();
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
