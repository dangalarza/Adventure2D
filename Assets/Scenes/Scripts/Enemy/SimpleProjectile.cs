using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir = Vector2.left;
    public int damage = 1;
    public float speed = 1f;
    public float lifetime = 3.0f;


    void Start()
    {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage, transform.position);        
            Destroy(gameObject, .1f);
        }

        if (collision.CompareTag("Wall"))
        {
            speed = 0;
            Destroy(gameObject, .5f);
        }
    }

    public void ChangeDirection(Vector2 direction)
    {
        dir = direction;
    }
}
