using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class HoodLogic : MonoBehaviour
{
    public float chargeTime = 1.5f;
    private HoodAnimator animator;
    private ProjectileTester projController;
    public float minAttackRange = 2f;
    private float targetDistance;
    private bool isActive = false;
    private bool isAttacking =  false;
    Coroutine attackRoutine;

    void Awake()
    {
        animator = GetComponent<HoodAnimator>();
        projController = GetComponent<ProjectileTester>();
    }
    void Update()
    {
        if(!isActive || isAttacking) return;
        //animator.PlayCharge();
        if (minAttackRange <= targetDistance)
        {
            attackRoutine = StartCoroutine(AttackSequence());
            //animator.PlayAttack();
            //projController.Fire();
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

    IEnumerator AttackSequence()
    {
        isAttacking = true;
        float elapsed = 0f;
        //float chargeTime = 1.5f;
        //start charging
        animator.PlayCharge();//.750 s
        //coroutine waits for charge
        while (elapsed < chargeTime)
        {
            if (minAttackRange <= targetDistance)
            {
                //print("Break to teleport...");
                //isAttacking = false;
                //yield break;
                //teleport and break
            }

            yield return null;
            elapsed += Time.deltaTime;
        }
        //on successful charge
        projController.Fire();
        animator.PlayAttack();
        isAttacking = false;
    }
}
