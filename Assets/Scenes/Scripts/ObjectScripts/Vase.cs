using UnityEngine;

public class Vase : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private Animator animator;
    private bool isBroken;

    public void Break()
    {
        if (isBroken) return;
        isBroken = true;

        col.enabled = false;
        animator.SetTrigger("Break");
        Destroy(gameObject, 3f);
    }
}
