using UnityEngine;

public class MovingPlatformButton : MonoBehaviour
{
    public MovingPlatform linkedPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            linkedPlatform?.Activate();
        }
    }
}