using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class DarknessManager : MonoBehaviour
{
    public static DarknessManager Instance { get; private set; }
    [SerializeField] private Light2D globalLight;
    private float originalLightLevel, targetIntensity;
    [SerializeField] private float fadeSpeed = 3f;
    private FairyController activeFairy = null;

    void Awake()
    {
        if (Instance == null) Instance = this;
        targetIntensity = originalLightLevel;
    }


/// <summary>
/// TODO: Work on global light hand off from controller to manager. 
/// Rename files for clarity. Controller should calculate darkness ratio based on player movement.
/// how to define exit from darkness? 
/// 
/// Kind of working currently. 
/// </summary>


    void Start()
    {
        originalLightLevel = globalLight.intensity;
    }

    public void UpdateGlobalLight(float darknessFraction)
    {

        print("Darkness Fraction: " + darknessFraction);
        targetIntensity = Mathf.Lerp(originalLightLevel, 0f, darknessFraction);
        
        if (activeFairy != null)
            activeFairy.AdjustLight(darknessFraction);

        globalLight.intensity = Mathf.Lerp(globalLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime); 
    }

    public void SetActiveFairy(FairyController fairy)
    {
        activeFairy = fairy;
    }

    public void UnregisterFairy(FairyController fairy)
    {
        if (activeFairy == fairy)
        {
            activeFairy = null;
        }
    }


}
