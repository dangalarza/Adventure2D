using UnityEngine;

public class ProjectileTester : MonoBehaviour
{
    [SerializeField] public Rigidbody2D projectile;
    protected Rigidbody2D prj;

    public virtual void Fire()
    {
        Vector2 t = transform.position;
        prj = Instantiate(projectile, t, Quaternion.identity);
    }
}
