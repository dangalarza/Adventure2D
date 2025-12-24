using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    private List<MazeDirection> solution = new()
    {
        MazeDirection.Left,
        MazeDirection.Up,
        MazeDirection.Right,
        MazeDirection.Down
    };

    private int progressIndex = 0;

    // Called by MazeDoor
    public void RecordPath(MazeDirection direction)
    {
        // Check current step
        if (direction == solution[progressIndex])
        {
            progressIndex++;
            Debug.Log("Correct");

            if (progressIndex >= solution.Count)
            {
                PuzzleComplete();
            }
        }
        else
        {
            ResetMaze();
        }
    }

    private void ResetMaze()
    {
        Debug.Log("Clearing...");
        progressIndex = 0;
        // TODO: teleport player to start
    }

    private void PuzzleComplete()
    {
        Debug.Log("Puzzle complete!");
        progressIndex = 0;
        // TODO: unlock exit, transition, reward player
    }
}