using UnityEngine;

public class HoodLogic : MonoBehaviour
{
    private HoodAnimator animator;
    public float minAttackRange = 2f;
    private float targetDistance;
    private bool isActive = false;

    void Awake()
    {
        animator = GetComponent<HoodAnimator>();
    }
    void Update()
    {
        if(!isActive) return;
        animator.PlayCharge();

        if(minAttackRange <= targetDistance)
        {
            animator.PlayAttack();
            //attack();
        }
        else
        {
            animator.PlayTeleport();
            //teleports();
        }

    }

    public void SetTargetDistance(float dist)
    {
        targetDistance = dist;
    }
    public void SetActive(bool active)
    {
        isActive = active;
    }
}
