using UnityEngine;

public class PathPlatform : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints to move between
    public float speed = 3f;
    private int currentTargetIndex = 0;
    private bool isMoving = true; // Starts moving by default

    private void Update()
    {
        if (isMoving && waypoints.Length > 1)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        Transform target = waypoints[currentTargetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % waypoints.Length;
        }
    }

    public void ToggleMovement()
    {
        isMoving = !isMoving; // Toggle movement on or off
    }
}