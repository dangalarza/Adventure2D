using System.Collections;
using UnityEngine;

public class ProjectileTester : MonoBehaviour
{
    [SerializeField] public Rigidbody2D projectile;
    public float speed = 4f;
    Rigidbody2D prj;

    void Start()
    {
        //Fire();
        //StartCoroutine(coroutine);
    }

    public void Fire()
    {
        Vector2 t = transform.position;
        prj = Instantiate(projectile, t, Quaternion.identity);
        prj.linearVelocity = Vector2.right * speed;
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        float time = 0f;
        
        while (time < 2f)
        {
            time += Time.deltaTime;
            yield return new WaitForSeconds(waitTime);
            print("Wait and print " + Time.time);
            Fire();
        }

    }
}
