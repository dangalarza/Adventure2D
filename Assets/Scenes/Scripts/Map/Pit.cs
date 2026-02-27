using UnityEngine;

public class Pit : MazeNode
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //playerTransform.position = targetNode.transform.position;
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(collision.GetComponent<PlayerController>().FallDownPit(targetNode.transform.position));
            
        }
    }
}
