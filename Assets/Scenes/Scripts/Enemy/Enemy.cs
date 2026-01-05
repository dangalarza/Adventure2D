using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 3;
    public float moveSpeed = 2f;
    public int contactDamage = 1;
    protected EnemyAnimator animator;
    public bool IsDead {get; private set;}
    public bool IsStunned {get; private set;}

    protected int currentHealth;

    protected virtual void Awake()
    {
        animator = GetComponent<EnemyAnimator>();
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount, Vector2 attackerPosition)
    {
        currentHealth -= amount;
        
        if (animator != null && currentHealth > 0)
        {
            animator.PlayHurt();
        }

        ApplyKnockback(attackerPosition);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyKnockback(Vector2 sourcePosition,
             float knockbackForce = 8f, float knockbackDuration = .2f)
    {
        
        if (IsDead) return;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null) return;
        Vector2 knockDirection = (transform.position - (Vector3)sourcePosition).normalized;

        // Apply an instant force
        rb.linearVelocity = knockDirection * knockbackForce;
        // Optionally, start a coroutine to stop movement after knockbackDuration
        StartCoroutine(KnockbackRoutine(knockbackDuration));
    }

    private IEnumerator KnockbackRoutine(float duration)
    {
        IsStunned = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        if (rb != null) rb.linearVelocity = Vector2.zero;
        
        IsStunned = false;
    }


    protected virtual void Die()
    {
        contactDamage = 0;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (animator != null)
        {
            animator.PlayDeath();
        }
        if (rb != null) rb.linearVelocity = Vector2.zero;
        
        IsDead = true;
        Destroy(gameObject, 1.5f);
        //drops here?
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsDead) return;
        if(!collision.gameObject.CompareTag("Player")) return;

        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            //Vector3 position =  transform.position;
            health.TakeDamage(contactDamage, transform.position);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(IsDead) return;
        if(!collision.gameObject.CompareTag("Player")) return;

        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            //Vector3 position =  transform.position;
            health.TakeDamage(contactDamage, transform.position);
        }
    }
}
