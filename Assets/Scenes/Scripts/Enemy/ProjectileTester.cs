using System.Collections.Generic;
using UnityEngine;

public class ProjectileTester : MonoBehaviour
{
    [SerializeField] public Rigidbody2D projectile;
    
    private List<Rigidbody2D> projectiles;
    public float speed = 4f;

    void Start()
    {
        Rigidbody2D p = Instantiate(projectile, new Vector2(-7, -11), Quaternion.identity);
        p.linearVelocity = Vector2.down * speed;
    }


}
