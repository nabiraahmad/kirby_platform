using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.hasKey = true; // Mark key as collected
            Destroy(gameObject); // Remove key from the scene
        }
    }
}