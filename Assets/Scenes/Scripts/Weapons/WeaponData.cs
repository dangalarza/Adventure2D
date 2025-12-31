using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon")]
public class WeaponData : ScriptableObject
{
    public int damage = 1;
    public float swingDuration = 0.15f;
    public Vector2 hitboxSize = new Vector2(1.2f, 0.8f);
    public Vector2 offsetRatio =  new Vector2(0f, 0f);
    public float knockbackForce = 8f;
    public float cooldown = 0.25f;

    public AnimatorOverrideController overrideController;
}

