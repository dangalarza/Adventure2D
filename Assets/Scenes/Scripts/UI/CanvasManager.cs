using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
