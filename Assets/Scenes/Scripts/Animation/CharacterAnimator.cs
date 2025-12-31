using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastFacing = Vector2.down;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Vector2 movement)
    {
        float speed = movement.magnitude;

        if (speed > 0)
            lastFacing = movement.normalized;

        string animName = GetAnimationName(lastFacing, speed);
        animator.Play(animName);
    }

    public void UpdateAnimation(string condition)
    {
        string animName;
        if (condition == "Dead")
        {
            animName = "Dead";
        }
        else return;
        animator.Play(animName);
    }

    private string GetAnimationName(Vector2 facing, float speed)
    {
        if (speed == 0)
        {
            if (facing.y > 0.5f) return "Idle_Up";
            if (facing.y < -0.5f) return "Idle_Down";
            if (facing.x < -0.5f) return "Idle_Left";
            return "Idle_Right";
        }
        else
        {
            if (facing.y > 0.5f) return "Walk_Up";
            if (facing.y < -0.5f) return "Walk_Down";
            if (facing.x < -0.5f) return "Walk_Left";
            return "Walk_Right";
        }
    }
}

