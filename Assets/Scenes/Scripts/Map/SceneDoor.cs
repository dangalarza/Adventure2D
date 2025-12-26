using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] public string doorId;
    [SerializeField] private string sendToDoorId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        SceneHandler.Instance.SwitchScene(sceneToLoad, sendToDoorId);
    }
}
