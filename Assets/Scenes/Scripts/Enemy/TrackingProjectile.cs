using UnityEngine;
using System.Collections;

public class TrackingProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
     string clip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Destroy(this.gameObject, 4f);
        //clip =  "blue_flame";
        clip =  "blue_skull";
    }
    void Update()
    {
        animator.Play(clip);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        clip =  "blue_flame";
        Destroy(this.gameObject,.8f);
    }
}

///
/// projectile
/// recieves direction (or calculates it?)
/// moves in direction at speed
/// disappears after time,
/// 