using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyChaseAI : MonoBehaviour
{
    public float detectionRange = 5f;

    private Transform player;
    private Rigidbody2D rb;
    private Enemy enemy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
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
    if (enemy.IsDead)
    {
        //rb.linearVelocity = Vector2.zero;
        return;
    }

    // IMPORTANT: let physics handle knockback
    if (enemy.IsStunned)
    {
        return;
    }
        
    if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > detectionRange)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * enemy.moveSpeed;
    }
}
