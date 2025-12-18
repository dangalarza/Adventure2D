using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    [SerializeField] private WeaponAnimator weaponAnimator;
    public float attackRadius = 0.3f;
    [SerializeField] private float attackCooldown = 0.3f;
    private float lastAttackTime;
    public LayerMask enemyLayers;
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    public void TryAttack(Vector2 facingDirection)
    {
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        lastAttackTime = Time.time;

        Vector2 attackPos =
            (Vector2)transform.position +
            playerController.FacingDirection * 0.5f;

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPos,
            attackRadius,
            enemyLayers
        );

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<Enemy>()?.TakeDamage(1);
        }

        weaponAnimator.PlayAttack(facingDirection);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Vector2 attackPos =
            (Vector2)transform.position +
            playerController.FacingDirection * 0.5f;
        Gizmos.DrawWireSphere(attackPos, attackRadius);
    }
#endif
}