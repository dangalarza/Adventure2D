using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;
    private GameObject player;
    private string targetSpawnId;

    void Awake()
    {
        // Singleton pattern (simple + sufficient here)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void SwitchScene(string sceneName, string spawnId)
    {
        targetSpawnId = spawnId;
        print(targetSpawnId);
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        GameObject spawn = FindSpawn(targetSpawnId);

        if (spawn != null)
        {
            player.transform.position = spawn.transform.position;
        }
        else
        {
            Debug.LogWarning($"Spawn not found for ID: {targetSpawnId}");
        }
    }

    private GameObject FindSpawn(string spawnId)
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");

        foreach (GameObject spawn in spawns)
        {
            SceneDoor door = spawn.GetComponent<SceneDoor>();
            if (door != null && door.doorId == spawnId)
            {
                return spawn;
            }
        }

        return null;
    }
}
