using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    [SerializeField] float invincibilityDuration = .5f;
    public HeartBar heartBar;
    private int currentHealth;
    private bool isInvincible;

    void Awake()
    {
        if (maxHealth > 28 )
        {
            Debug.Log("Excessive max heath. Reverting to 28");
            maxHealth = 28;
        }
        else if(maxHealth < 1)
        {
            Debug.Log("Max health cannot be less than 1.");
            maxHealth = 1;
        }
        currentHealth =  maxHealth;
    }

    public void TakeDamage(int damage, Vector3 sourcePosition)
    {   
        //Vector2 hitDirection =  transform.position - sourcePosition;--------------*
        if (isInvincible) return;
        currentHealth -= damage;
        heartBar.UpdateHearts();

        if(currentHealth <= 0)
        {
            isInvincible = true;
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }
    void Die()
    {
        Debug.Log("You died!");
        GetComponent<PlayerController>().SetMovementEnabled(false);
    }

    IEnumerator InvincibilityCoroutine()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        isInvincible = true;
        
        float elapsed = 0f;
        while (elapsed < invincibilityDuration)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }
        

        sprite.enabled = true;
        isInvincible = false;
    }

    void UpgradeHealth(int heartUp = 1)
    {
        maxHealth += heartUp;
        currentHealth = maxHealth;
    }

        public void ApplyKnockback(Vector2 sourcePosition, float knockbackForce = 8f)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null) return;
        Vector2 knockDirection = (transform.position - (Vector3)sourcePosition).normalized;

        // Apply an instant force
        rb.linearVelocity = knockDirection * knockbackForce;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
