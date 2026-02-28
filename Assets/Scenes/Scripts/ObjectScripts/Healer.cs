using UnityEngine;

public class Healer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health.getCurrentHealth() == health.getMaxHealth()) return;
            else
            {
                health.FullHeal();
                Destroy(gameObject);
            }
            
        }
    }
}
