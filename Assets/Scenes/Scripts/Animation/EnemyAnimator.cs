using UnityEngine;

//[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    protected Animator animator;


    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void PlayHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public virtual void PlayDeath()
    {
        animator.SetBool("IsDead", true);
    }
}

