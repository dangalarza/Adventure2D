using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    private Animator animator;
    private Transform pivot;

    void Awake()
    {
        animator = GetComponent<Animator>();
        pivot = transform.parent; // parent GameObject is WeaponHolder
    }

    public void PlayAttack(Vector2 facingDirection)
    {
        // Position weapon slightly in front of player
        pivot.localPosition = facingDirection * 0.5f;

        // Rotate weapon to match direction
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        pivot.localRotation = Quaternion.Euler(0, 0, angle);

        // Trigger animation
        animator.SetTrigger("Attack");
    }
}
