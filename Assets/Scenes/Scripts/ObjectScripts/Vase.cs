using UnityEngine;
using System;

public class Vase : MonoBehaviour
{
    public static event Action<Vase> OnVaseBroken;

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

        OnVaseBroken?.Invoke(this);
    }
}
