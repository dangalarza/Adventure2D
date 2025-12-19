using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    [SerializeField] private WeaponAnimator weaponAnimator;
    public float attackRadius = 0.3f;
    [SerializeField] private float attackCooldown = 0.3f;
    public int attackDamage = 1;
    private float lastAttackTime;
    public LayerMask enemyLayers;
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }


    public void TryAttack(Vector2 facingDirection)
    {
        //cooldown
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        lastAttackTime = Time.time;

        Vector2 attackPos =
            (Vector2)transform.position +
            playerController.FacingDirection * 0.5f;

        //notice array, catches all enemies in hitbox
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPos,
            attackRadius,
            enemyLayers
        );

        //Apply damage for each enemy in hit box
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
                {
                    //Weapon tells enemy its location and damage
                    enemy.TakeDamage(attackDamage, transform.position);
                }

        }

        weaponAnimator.PlayAttack(facingDirection);
    }
}