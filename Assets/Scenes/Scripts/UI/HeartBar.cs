using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class HeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth health;
    int maxHealth;
    int heartsLen;
    List<heartController> hearts = new List<heartController>();

    void Start()
    {
        maxHealth = health.getMaxHealth();
        heartsLen =  maxHealth/2 + maxHealth%2;
        DrawHearts();
    }

    public void DrawHearts()
    {
        //2 health is 1 heart***
        //Create list of hearts based on max health.
        ClearHearts(); 
        for (int k=0; k < heartsLen; k++)
        {
            CreateEmptyHeart();
        }

        UpdateHearts();
    }

    public void UpdateHearts()
    {
        int currentHealth = health.getCurrentHealth();
        
        for(int k = 0; k < hearts.Count; k++)
        {
            // Each heart represents 2 health points
            // heartValue tells us how much health is "missing" from this heart's quota
            int heartValue = ((k+1)*2) - currentHealth;
            //i.e. 0 means none missing.
            if(heartValue <= 0) hearts[k].SetHeartImage(HeartStatus.Full);
            else if(heartValue == 1) hearts[k].SetHeartImage(HeartStatus.Half);
            else hearts[k].SetHeartImage(HeartStatus.Empty);
        }
    }
    public void CreateEmptyHeart()
    {
        //instantiate heartPrefab as child of hearts grid
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        //get script component of prefab to set image
        heartController heartComponent = newHeart.GetComponent<heartController>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        //add it to list, the heart bar
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        //Destroy all hearts, start a new list
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<heartController>();
    }
}
