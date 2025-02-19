using UnityEngine;

public class MovingPlatformButton : MonoBehaviour
{
    public MovingPlatform[] linkedPlatforms; // Array of platforms to control

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            foreach (var platform in linkedPlatforms) 
            {
                platform?.Activate();
            }
        }
    }
}