using UnityEngine;

public class MazeNode : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    //public Transform spawnPoint;
    public MazeNode targetNode;

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerTransform.position = targetNode.transform.position;
    }
}

