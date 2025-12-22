using UnityEngine;

/// <summary>
/// Player presses attack
/// PlayerCombat checks cooldown
/// PlayerCombat tells Weapon: “Attack”
/// Weapon handles animation + hitbox
/// Weapon applies damage via collision
/// </summary>

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float attackCooldown = 0.3f;

    private float lastAttackTime;
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TryAttack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        lastAttackTime = Time.time;

        weapon.Attack(playerController.FacingDirection);
    }

    public void TryEquip(WeaponData data)
    {
        weapon.Equip(data);
    }
}
