using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius = 0.3f;
    public float attackCooldown = 0.4f;
    public LayerMask enemyLayers;

    private float lastAttackTime;
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryAttack();
        }
    }

    void TryAttack()
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