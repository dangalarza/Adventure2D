using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class FairyController : MonoBehaviour
{
    [SerializeField] private Transform glow;
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

        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void AdjustLight(float darknessFraction)
    {
        float scale = Mathf.Lerp(1f, glowScaleMultiplier, darknessFraction);
        glow.localScale = Vector3.one * 2.5f * scale;
    }   
}
