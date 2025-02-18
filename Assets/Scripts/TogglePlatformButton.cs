using UnityEngine;

public class TogglePlatformButton : MonoBehaviour
{
    public TogglePlatform[] linkedPlatforms; // Array of platforms to toggle

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var platform in linkedPlatforms)
            {
                platform?.Toggle(); // Toggle each linked platform individually
            }
        }
    }
}