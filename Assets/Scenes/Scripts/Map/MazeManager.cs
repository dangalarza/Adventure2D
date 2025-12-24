using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    List<String> dirs = new List<string> { "left", "up", "right","down" };
    List<String> pathList = new List<string>();
    public void recordPath(string direction)
    {
        pathList.Add(direction);
        if (pathList.Count <= dirs.Count)
        compareLists();
        else print("Puzzle complete. Player took last exit.");
    }

    public void compareLists()
    {
        //set 0 based index
        int count = pathList.Count - 1;

        // loop thru each list, compare, check list len equal
        if (pathList[count].Equals(dirs[count]))
        {
            //Transition to next maze square
            print("Correct");
        }
        else
        {
            //return to first maze square
            print("Clearing...");
            pathList.Clear();
        }

    }
}
