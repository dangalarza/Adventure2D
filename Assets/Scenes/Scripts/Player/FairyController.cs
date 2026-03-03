using UnityEngine;

public class FairyController : MonoBehaviour
{
    private Transform playerTransform;
    private float followDistance = 2f;
    private float moveSpeed = 3f;

    [SerializeField] private float y_offset = .8f;


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
}
