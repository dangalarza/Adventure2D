using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarknessController : MonoBehaviour
{
    [SerializeField] Light2D globalLight;
    private float originalLightLevel, targetIntensity;
    [SerializeField] float fadeSpeed = 3f;
    [SerializeField] float startX = 0;
    [SerializeField] float endX = 0;
    private bool playerInDarkness = false;
    private Transform playerpos;

    void Start()
    {
        targetIntensity = originalLightLevel = globalLight.intensity;
    }


    void Update()
    {
        if (playerInDarkness)
        {
            float playerX = playerpos.position.x;
            float t = Mathf.InverseLerp(startX, endX, playerX);
            targetIntensity = Mathf.Lerp(originalLightLevel, 0, t);
        }
        else if (!playerInDarkness && globalLight.intensity < originalLightLevel)
        {
            targetIntensity = originalLightLevel;
        }
        globalLight.intensity = Mathf.Lerp(
            globalLight.intensity,
            targetIntensity,
            fadeSpeed * Time.deltaTime
        );
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDarkness = true;
            playerpos = collision.transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDarkness = false;
            playerpos = null;
        }
    }
}
