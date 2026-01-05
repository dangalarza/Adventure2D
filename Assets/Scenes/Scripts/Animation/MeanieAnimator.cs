using UnityEngine;

//[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Enemy))]
public class MeanieAnimator : EnemyAnimator
{

    protected Rigidbody2D rb;
    protected Enemy enemy;

    new void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        bool isMoving = rb.linearVelocity.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", isMoving);
    }

}


