using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Enemy enemy;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        bool isMoving = rb.linearVelocity.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", isMoving);
    }

    public void PlayHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void PlayDeath()
    {
        animator.SetBool("IsDead", true);
    }
}

