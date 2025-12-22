using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    [SerializeField] private WeaponAnimator weaponAnimator;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private LayerMask enemyLayers;

    private void Awake()
    {
        hitbox.enabled = false;
    }

    public void Attack(Vector2 facingDirection)
    {
        transform.right = facingDirection;
        hitbox.size = data.hitboxSize;
        hitbox.enabled = true;

        // play animation here

        Invoke(nameof(DisableHitbox), data.swingDuration);
        weaponAnimator.PlayAttack(facingDirection);
    }

        public void Equip()
    {
        animator.runtimeAnimatorController = data.overrideController;
    }

    private void DisableHitbox()
    {
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Enemy enemy)) return;

        enemy.TakeDamage(data.damage, transform.position);
    }
}

