using UnityEngine;

public class PlatformButtonTrigger : MonoBehaviour
{
    public MovingPlatform linkedPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        // idk if groundCheck should be tagged with player idk

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the button => activating platform");
            linkedPlatform?.Activate();
        }
        else
        {
            Debug.Log("Collision ignored - object is not Player.");
        }
    }
}