using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementOffset = new Vector3(0, 5, 0); // Offset for movement direction
    public float speed = 2f;
    public float delay = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false; 

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + movementOffset;
    }

    public void Activate()
    {
        if (!isMoving) 
        {
            StartCoroutine(MovePlatform());
        }
    }

    private IEnumerator MovePlatform()
    {
        isMoving = true;

        // Move to target
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        // Wait at target position
        yield return new WaitForSeconds(delay);

        // Move back to original
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false; // Allow new activations
    }
}