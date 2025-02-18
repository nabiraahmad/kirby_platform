using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform
    public float smoothSpeed = 0.125f;   // Smoothing speed
    public Vector3 offset;         // Offset to keep a distance from the player

    void LateUpdate()
    {
        // Only track horizontal position, keep the vertical position fixed
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, offset.z);  
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;  // Move camera to smooth position
    }
}


