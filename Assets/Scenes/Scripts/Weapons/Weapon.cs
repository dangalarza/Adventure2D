using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weapon;
    [SerializeField] private WeaponAnimator weaponAnimator;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private LayerMask enemyLayers;
    

    private void Awake()
    {
        hitbox.enabled = false;
        animator.runtimeAnimatorController = weapon.overrideController;
    }

    public void Attack(Vector2 facingDirection)
    {
        hitbox.size = weapon.hitboxSize;
        hitbox.offset = hitbox.size * weapon.offsetRatio;
        hitbox.enabled = true;

        // play animation
        Invoke(nameof(DisableHitbox), weapon.swingDuration);
        weaponAnimator.PlayAttack(facingDirection);
    }

    public void Equip( WeaponData nextWeapon)
    {
        //Set scriptObject to next, update animator.
        weapon = nextWeapon;
        animator.runtimeAnimatorController = nextWeapon.overrideController;
    }

    private void DisableHitbox()
    {
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Enemy enemy)) return;
        enemy.TakeDamage(weapon.damage, transform.position);
    }
}

