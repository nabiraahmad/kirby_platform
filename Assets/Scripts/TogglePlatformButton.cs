using UnityEngine;

public class TogglePlatformButton : MonoBehaviour
{
    public TogglePlatform linkedPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            linkedPlatform?.Toggle();
        }
    }
}