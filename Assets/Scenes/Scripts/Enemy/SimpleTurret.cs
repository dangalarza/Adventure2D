using UnityEngine;
using System.Collections;

public class SimpleTurret : ProjectileTester
{
    private bool isFiring {set;get;}
    public enum Direction { Up, Down, Left, Right }
    public float Xoffset, Yoffset = 0;
    [SerializeField] private Direction startingDirection;

    void Start()
    {
        isFiring = false;
    }
    public override void Fire()
    {
        Vector2 t = transform.position;
        t.x += Xoffset;
        t.y += Yoffset;
        prj = Instantiate(projectile, t ,Quaternion.identity);
        prj.GetComponent<SimpleProjectile>().ChangeDirection(GetDirectionVector());
    }


    void Update()
    {
        if (!isFiring)
        {
            StartCoroutine(FireRoutine());
        }
    }
    IEnumerator FireRoutine()
    {
        isFiring = true;
        float time = 0f;
        while (isFiring)
        {
            if (time > 3f)
            {
                Fire();
                isFiring = false;
                time = 0f;
            }
            yield return null;
            time += Time.deltaTime;
        }
        
    }

    private Vector2 GetDirectionVector()
    {
        return startingDirection switch
        {
            Direction.Up    => Vector2.up,
            Direction.Down  => Vector2.down,
            Direction.Left  => Vector2.left,
            Direction.Right => Vector2.right,
            _               => Vector2.zero
        };
    }
}
