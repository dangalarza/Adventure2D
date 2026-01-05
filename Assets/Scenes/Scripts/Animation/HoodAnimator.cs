using Unity.VisualScripting;
using UnityEngine;

public class HoodAnimator : EnemyAnimator
{
    private bool wasActive =  false;

    public void SetActive()
    {
        wasActive = true;
        GetComponentInParent<SpriteRenderer>().enabled = true;
        animator.SetBool("IsActive", true);
    }

    public void SetInactive()
    {
        if (!wasActive) return;
        if (wasActive) PlayTeleport();
        wasActive = false;
        animator.SetBool("IsActive", false);
    }

    public void PlayCharge()
    {
        animator.SetTrigger("Charging");
    }

    public void PlayTeleport()
    {
        animator.SetTrigger("Teleport");
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }
}