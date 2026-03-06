using UnityEngine;
using System.Collections;

public class SimpleTurret : ProjectileTester
{
    private Coroutine fireRoutine;
    public enum Direction { Up, Down, Left, Right }
    public float fireRate = 3f;
    [SerializeField] private Direction startingDirection;

    public override void Fire()
    {
        Vector2 t = transform.position;
        prj = Instantiate(projectile, t ,Quaternion.identity);
        prj.GetComponent<SimpleProjectile>().ChangeDirection(GetDirectionVector());
    }


    void Update()
    {
        if (fireRoutine == null)
        {
            fireRoutine = StartCoroutine(FireRoutine());
        }
    }
    IEnumerator FireRoutine()
    {
        float time = 0f;
        while (true)
        {
            if (time > fireRate)
            {
                Fire();
                time = 0f;
            }
            time += Time.deltaTime;
            yield return null;
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
