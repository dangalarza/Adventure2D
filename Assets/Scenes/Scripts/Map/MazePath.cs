using System;
using Unity.VisualScripting;
using UnityEngine;

public class MazePath : MonoBehaviour
{
    [SerializeField] private MazeDirection pathDirection;
    [SerializeField] private MazeManager mazeManager;



    void OnTriggerEnter2D (Collider2D other)
    {
        //only player can enter
        if (!other.CompareTag("Player")) return;
        mazeManager.RecordPath(pathDirection);
    }
}
