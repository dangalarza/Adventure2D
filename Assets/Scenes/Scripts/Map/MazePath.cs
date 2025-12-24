using System;
using Unity.VisualScripting;
using UnityEngine;

public class MazePath : MonoBehaviour
{
    [SerializeField] private string pathDirection;
    [SerializeField] MazeManager mazeManager;

    void Awake()
    {
        if (pathDirection != "left" && pathDirection != "right" && pathDirection != "up" && pathDirection != "down")
        {
            print("Invalid name: " + pathDirection);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //only player can enter
        if (!other.CompareTag("Player")) return;
        mazeManager.recordPath(pathDirection);
    }

    public string getPath()
    {
        return pathDirection;
    }

}
