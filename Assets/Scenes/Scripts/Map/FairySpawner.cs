using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FairySpawner : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject fairyPrefab;
    private GameObject activeFairy;

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
        if (activeFairy == null)
        {
            activeFairy = Instantiate(fairyPrefab, vase.transform.position, Quaternion.identity);
            
            FairyController fairyController = activeFairy.GetComponent<FairyController>();
            fairyController.Initialize(playerTransform);
            DarknessManager.Instance.SetActiveFairy(fairyController);
        }
    }
}
