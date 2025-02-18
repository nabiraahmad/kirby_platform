using UnityEngine;

public class PathPlatformButton : MonoBehaviour
{
    public PathPlatform[] linkedPlatforms; // Array of platforms to toggle

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var platform in linkedPlatforms)
            {
                platform?.ToggleMovement(); // Toggle each platform individually
            }
        }
    }
}