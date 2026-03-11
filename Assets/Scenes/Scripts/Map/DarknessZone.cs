using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarknessZone : MonoBehaviour
{
    //[SerializeField] Light2D globalLight;
    //private float originalLightLevel, targetIntensity;
    //[SerializeField] float fadeSpeed = 3f;
    [SerializeField] float startX = 0;
    [SerializeField] float endX = 0;
    private float t = 0;
    private bool playerInDarkness = false;
    private Transform playerpos;


    void Update()
    {
        if (playerInDarkness)
        {
            // get player's x position
            float playerX = playerpos.position.x;
            // calculates percentage of player's x between start and end
            t = Mathf.InverseLerp(startX, endX, playerX);
            DarknessManager.Instance.UpdateGlobalLight(t);
        }
        else if (!playerInDarkness)// && globalLight.intensity < originalLightLevel)
        {
            t = 0f;
        }
        
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
