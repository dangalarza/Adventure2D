using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class FairyController : MonoBehaviour
{
    [SerializeField] private Transform glow;

    [SerializeField] private float bobAmplitude = 0.15f;
    [SerializeField] private float bobFrequency = 2f;
    [SerializeField] private float swayAmplitude = 0.25f;
    [SerializeField] private float swayFrequency = 1.2f;
    private Transform playerTransform;
    private float followDistance = 2f;
    private float moveSpeed = 3f;


    [SerializeField] private float y_offset = .8f;
    [SerializeField] private float glowScaleMultiplier = 1.5f;


    public void Initialize(Transform player)
    {
        playerTransform = player;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = playerTransform.position - playerTransform.forward * followDistance;
        targetPosition.y += y_offset;

        Vector3 basePosition = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        transform.position = ApplyFloat(basePosition);
    }

    private Vector3 ApplyFloat(Vector3 basePosition)
    {
        // Add bob and sway on top of the base position
        float bob = Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        float sway = Mathf.Sin(Time.time * swayFrequency + 1.2f) * swayAmplitude;

        return basePosition + new Vector3(sway, bob, 0f);
    }

    public void AdjustLight(float darknessFraction)
    {
        float scale = Mathf.Lerp(1f, glowScaleMultiplier, darknessFraction);
        glow.localScale = Vector3.one * 2.5f * scale;
    }   
}
