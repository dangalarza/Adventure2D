using UnityEngine;

public class MazeNode : MonoBehaviour
{
    //[SerializeField] Transform playerTransform;
    //public Transform spawnPoint;
    public MazeNode targetNode;

    void Awake()
    {
        //playerTransform = PlayerController.instance.transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //playerTransform.position = targetNode.transform.position;
        if (collision.CompareTag("Player"))
        {
            PlayerController.TeleportTo(targetNode.transform.position);
        }
    }
}

