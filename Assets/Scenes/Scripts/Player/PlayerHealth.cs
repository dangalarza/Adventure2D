using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    [SerializeField] float invincibilityDuration = .5f;
    private int currentHealth;
    private bool isInvincible;

    void Start()
    {
        currentHealth =  maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        currentHealth -= damage;
        Debug.Log("Current health: "  + currentHealth);

        if(currentHealth <= 0)
        {
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
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void UpgradeHealth(int heartUp = 1)
    {
        maxHealth += heartUp;
        currentHealth = maxHealth;
    }
}
