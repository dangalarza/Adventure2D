using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void OnEnable()
    {
        Vase.OnVaseBroken += HandleVaseBroken;
    }

    private void OnDisable()
    {
        Vase.OnVaseBroken -= HandleVaseBroken;
    }

    private void HandleVaseBroken(Vase vase)
    {
        print("A vase was broken at position: " + vase.transform.position); 
        //SpawnFairyAt(vase.transform.position);
    }
}
