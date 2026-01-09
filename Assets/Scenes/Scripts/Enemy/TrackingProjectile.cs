using System.Collections;
using UnityEngine;


public class TrackingProjectile : MonoBehaviour
{
    GameObject player;
    Vector2 target;
    private Rigidbody2D rb;
    private Animator animator;
    private string clip;
    bool impact = false;
    public float speed, homingStrength;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.GetComponent<Transform>().position;
        }
        //
        Destroy(gameObject, 5f);
        //
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        clip =  "blue_skull";
        StartCoroutine(TrackPlayer());
        animator.Play(clip);
    }
    void Update()
    {  
        checkDirection();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        clip =  "blue_flame";
        animator.Play(clip);
        impact = true;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1,transform.position);
        }
        Destroy(gameObject,.8f);
    }

    IEnumerator TrackPlayer()
    {

        Vector2 currentVelocity = rb.linearVelocity; // start with initial velocity
        float elapsed = 0f;
        while (!impact  && elapsed < 3.7f)
        {
            if (player != null)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                currentVelocity = Vector2.Lerp(currentVelocity, direction * speed, homingStrength);
                rb.linearVelocity = currentVelocity;
            }

            elapsed += Time.deltaTime;
            yield return null;

        }
        clip = "blue_flame";
        animator.Play(clip);
        rb.linearVelocity = Vector2.zero;
    }

    void checkDirection()
    {
        if (rb.linearVelocityX > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
